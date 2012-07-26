﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditPosts.Db.Repositories;
using EditPosts.Domain.Models;
using EditPosts.PresentationServices.Services;
using EditPosts.PresentationServices.ViewModels.PostsModels;
using Iesi.Collections.Generic;

namespace EditPosts.Views.Controllers
{
    [ValidateInput(false)]
    public class PostController : Controller
    {
        /**
         * Main page, view 5 latests post, and 3 most popular post
         */

        private readonly IPostPresentationService postPresentationService;
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public PostController(IPostRepository postRepository, ITagRepository tagRepository,
                              IPostPresentationService postPresentationService)
        {
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            this.postPresentationService = postPresentationService;
        }

        //У администратора должна быть страничка, на которой виден список всех созданных постов, кнопки Add, Edit, Delete.
        public ActionResult Admin(int? page)
        {
            return View(postPresentationService.LoadPostAdminModel());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return RedirectToAction("Edit", new {id = default(int)});
        }

        [HttpPost]
        public ActionResult Delete(int id, int page)
        {
            postRepository.Delete(id);
            int currentPage = page;

            return RedirectToAction("Admin", new {page = currentPage});
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(postPresentationService.LoadPostDetailsViewModel(id));
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            string cookieName = string.Format("{0}", id);
            bool isFirstView = Request.Cookies[cookieName] == null;

            if (isFirstView)
            {
                var cookie = new HttpCookie(cookieName)
                                 {Expires = DateTime.Now.AddDays(1), Value = string.Format("{0}", id)};
                Response.Cookies.Add(cookie);
            }

            PostEditViewModel model = postPresentationService.LoadPostEditViewModel(id, isFirstView);
            ViewBag.OldName = model.Post.Name;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PostEditViewModel postEditViewModel)
        {
            if (ModelState.IsValid)
            {
                string[] newTags = postEditViewModel.Tags != null
                                       ? postEditViewModel.Tags.Split(';')
                                       : new string[0];

                Post post = postRepository.Get(postEditViewModel.Post.Id);
                post.Name = postEditViewModel.Post.Name;
                post.Body = postEditViewModel.Post.Body;
                post.HitCount = postEditViewModel.Post.HitCount;
                post.PostDate = postEditViewModel.Post.PostDate;

                postRepository.Update(post);

                var mustRemovedTags = new Stack<Tag>();

                foreach (Tag x in post.Tags)
                    if (!newTags.Contains(x.Name))
                        mustRemovedTags.Push(x);

                while (mustRemovedTags.Count != 0)
                {
                    Tag tag = mustRemovedTags.Pop();
                    post.Tags.Remove(tag);
                }
                postRepository.Update(post);
                foreach (string newTag in newTags)
                    if (!String.IsNullOrWhiteSpace(newTag))
                    {
                        if (tagRepository.All().Count(t => t.Name.Equals(newTag)) == 0)
                        {
                            var newPostTag = new Tag {Name = newTag, Posts = new HashedSet<Post>()};
                            newPostTag.Posts.Add(post);
                            tagRepository.Save(newPostTag);
                        }
                        else
                        {
                            Tag tag = tagRepository.All().Single(t => t.Name.Equals(newTag));
                            tag.Posts.Add(post);
                            post.Tags.Add(tag);
                            tagRepository.Update(tag);
                        }
                    }

                tagRepository.DeleteUnusedTags();

                return RedirectToAction("Details", new {id = postEditViewModel.Post.Id});
            }
            ViewBag.OldName = postRepository.Get(postEditViewModel.Post.Id).Name;
            return View(postEditViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(postPresentationService.LoadPostIndexModel());
        }

        /**
         * View one post, is determined by the id.
         * Paralell, must work with cookies : check , the client must be have cookies
         * Client containt cookie means that he view this post before
         * Client doesn't containt cookie means that he view this post for the first time
         */
    }
}