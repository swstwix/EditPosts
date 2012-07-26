using System;
using System.Web.Mvc;
using Castle.Windsor;
using EditPosts.PresentationServices.Services;

namespace EditPosts.Views.Binders
{
    public class PostEditViewModelBinder : DefaultModelBinder
    {
        private readonly IWindsorContainer windsorContainer;

        public PostEditViewModelBinder(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                              Type modelType)
        {
            var postPresentationService = windsorContainer.Resolve<IPostPresentationService>();
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