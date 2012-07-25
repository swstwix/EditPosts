using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditPosts.Db.Repositories;
using EditPosts.Domain.Models;
using EditPosts.PresentationServices.Services;
using EditPosts.Views.Models;
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
            var viewModel = new PostAdminViewModel
                                {CurrentPage = page ?? 1, PostsPerPage = 30, Posts = postRepository.Query()};
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var post = new Post {Body = "", Name = "", PostDate = DateTime.Now};
            postRepository.Save(post);
            return RedirectToAction("Details", new {id = post.Id});
        }

        [HttpPost]
        public ActionResult Delete(int id, int page)
        {
            postRepository.Delete(id);
            int currentPage = page;

            return RedirectToAction("Admin", new {page = currentPage});
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Details(int id)
        {
            Post post = postRepository.Get(id);
            if (post == null)
                throw new HttpException(404, string.Format("Wrong post id : '{0}'", id));

            string cookieName = string.Format("{0}", id);
            bool isFirstView = Request.Cookies[cookieName] == null;

            if (isFirstView)
            {
                var cookie = new HttpCookie(cookieName)
                                 {Expires = DateTime.Now.AddDays(1), Value = string.Format("{0}", id)};
                Response.Cookies.Add(cookie);
            }

            if (isFirstView)
                postRepository.IncHitCount(post.Id);

            var viewModel = new PostDetailsViewModel {Post = post, AvailableTags = tagRepository.AvailableTags()};
            ViewBag.OldName = post.Name;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Details(PostDetailsViewModel postDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                string[] newTags = postDetailsViewModel.Tags != null
                                       ? postDetailsViewModel.Tags.Split(';')
                                       : new string[0];

                Post post = postRepository.Get(postDetailsViewModel.Post.Id);
                post.Name = postDetailsViewModel.Post.Name;
                post.Body = postDetailsViewModel.Post.Body;
                post.HitCount = postDetailsViewModel.Post.HitCount;
                post.PostDate = postDetailsViewModel.Post.PostDate;

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

                return RedirectToAction("ViewPost", new {id = postDetailsViewModel.Post.Id});
            }
            ViewBag.OldName = postRepository.Get(postDetailsViewModel.Post.Id).Name;
            return View(postDetailsViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(postPresentationService.LoadPostIndexModel());
        }

        [HttpGet]
        public ActionResult TagsAndPopularPosts()
        {
            return View(postPresentationService.LoadTagCloudWithBestPostsModel());
        }

        /**
         * View one post, is determined by the id.
         * Paralell, must work with cookies : check , the client must be have cookies
         * Client containt cookie means that he view this post before
         * Client doesn't containt cookie means that he view this post for the first time
         */

        [HttpGet]
        public ActionResult ViewPost(int id)
        {
            Post post = postRepository.Get(id);
            return View(post);
        }
    }
}