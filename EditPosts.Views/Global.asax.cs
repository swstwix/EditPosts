using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using EditPosts.Dapper;
using EditPosts.Domain.Repositories;
using EditPosts.PresentationServices.Services;
using EditPosts.PresentationServices.Services.Concret;
using EditPosts.PresentationServices.ViewModels.PostsModels;
using EditPosts.Views.Binders;

namespace EditPosts.Views
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Post", action = "Index", id = UrlParameter.Optional } 
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BootstrapDependencyResolver();

            AddModelBinders();
        }

        private void BootstrapDependencyResolver()
        {
            var builder = new ContainerBuilder();

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Posts"].ConnectionString;

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();

            builder
                .Register(x => new PostRepository(connectionString))
                .As<IPostRepository>();

            builder
                .Register(x => new TagRepository(connectionString))
                .As<ITagRepository>();

            builder
                .Register(x => new PostPresentationService(x.Resolve<IPostRepository>(), x.Resolve<ITagRepository>()))
                .As<IPostPresentationService>();

            builder
                .Register(x => new TagPresentationService(x.Resolve<ITagRepository>(), x.Resolve<IPostRepository>()))
                .As<ITagPresentationService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void AddModelBinders()
        {
            ModelBinders.Binders.Add(typeof(PostEditViewModel), new PostEditViewModelBinder());
        }
    }
}