using System.Web;
using System.Web.Mvc;

using EditPosts.Db.Repositories;
using EditPosts.Db.Repositories.Concret;
using EditPosts.Views.Models;

namespace EditPosts.Views.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public ActionResult Index(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var viewModel = new TagIndexViewModel { Tag = tagRepository.Get(name) };
                if (viewModel.Tag != null)
                {
                    return View(viewModel);
                }
            }
            throw new HttpException(404, string.Empty);
        }
    }
}