using System;
using System.Web;
using System.Web.Mvc;
using EditPosts.PresentationServices.Services;
using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.Views.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class PostAdminController : Controller
    {
        /**
         * Main page, view 5 latests post, and 3 most popular post
         */

        private readonly IPostPresentationService postPresentationService;

        public PostAdminController(
            IPostPresentationService postPresentationService)
        {
            this.postPresentationService = postPresentationService;
        }

        //У администратора должна быть страничка, на которой виден список всех созданных постов, кнопки Add, Edit, Delete.
        public ActionResult Index(int? page)
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

            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }

            return View(postEditViewModel);
        }

        /**
         * View one post, is determined by the id.
         * Paralell, must work with cookies : check , the client must be have cookies
         * Client containt cookie means that he view this post before
         * Client doesn't containt cookie means that he view this post for the first time
         */
    }
}