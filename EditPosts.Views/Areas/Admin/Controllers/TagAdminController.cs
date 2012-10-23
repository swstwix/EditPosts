using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditPosts.PresentationServices.Services;

namespace EditPosts.Views.Areas.Admin.Controllers
{
    public class TagAdminController : Controller
    {
        private readonly ITagPresentationService tagPresentationService;

        public TagAdminController(ITagPresentationService tagPresentationService)
        {
            this.tagPresentationService = tagPresentationService;
        }

        public JsonResult TagsForAutocomplete(string term)
        {
            return Json(tagPresentationService.LoadTagNamesContains(term).Select(n => new
            {
                label = n,
                value = n,
            })
                , JsonRequestBehavior.AllowGet);
        }

    }
}
