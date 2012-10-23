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

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(postPresentationService.LoadPostDetailsViewModel(id));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var x = string.Format("{0}", (string) null);
            return View(postPresentationService.LoadPostIndexModel());
        }
    }
}