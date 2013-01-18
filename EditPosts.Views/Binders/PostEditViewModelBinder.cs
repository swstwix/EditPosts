using System;
using System.Web.Mvc;
using EditPosts.PresentationServices.Services;

namespace EditPosts.Views.Binders
{
    public class PostEditViewModelBinder : DefaultModelBinder
    {
        public PostEditViewModelBinder()
        {
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                              Type modelType)
        {
            var postPresentationService = DependencyResolver.Current.GetService<IPostPresentationService>();
            var str = controllerContext.RouteData.Values["id"].ToString();
            int id = 0;
            int.TryParse(str, out id);
            if (id != 0)
            {
                return postPresentationService.LoadPostEditViewModel(id, false);
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}