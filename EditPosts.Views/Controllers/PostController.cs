using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public PostController(
            IPostPresentationService postPresentationService)
        {
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
        public ActionResult Delete(int id)
        {
            postPresentationService.DeletePost(id);

            return RedirectToAction("Admin");
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
            ViewBag.OldName = model.Name;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PostEditViewModel postEditViewModel)
        {
            if (ModelState.IsValid)
            {
                postPresentationService.SavePostEditViewModel(postEditViewModel);
                return RedirectToAction("Admin");
            }

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