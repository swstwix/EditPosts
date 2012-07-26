using System.Linq;
using System.Web.Mvc;
using EditPosts.PresentationServices.Services;

namespace EditPosts.Views.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagPresentationService tagPresentationService;

        public TagController(ITagPresentationService tagPresentationService)
        {
            this.tagPresentationService = tagPresentationService;
        }

        public ActionResult Index(string name)
        {
            return View(tagPresentationService.LoadTagIndexModel(name));
        }

        public ActionResult TagCloud()
        {
            return View(tagPresentationService.LoadTagCloudModel());
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