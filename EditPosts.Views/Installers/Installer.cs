using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EditPosts.Db;
using EditPosts.Db.Repositories;
using EditPosts.Domain.Repositories;
using EditPosts.PresentationServices.Services;
using NHibernate;
using TagRepo = EditPosts.Dapper.TagRepository;

namespace EditPosts.Views.Installers
{
    public class Installer : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Posts"].ConnectionString;

            container.Register(
                Component.For<IPostRepository>()
                .ImplementedBy<PostRepository>().LifestylePerWebRequest()
            );

            container.Register(
                Component.For<ITagRepository>()
                .ImplementedBy<TagRepo>().DependsOn(new { connectionString }).LifestylePerWebRequest()
            );

            container.Register(
                Classes.FromThisAssembly().BasedOn<IRepository>());

            container.Register(AllTypes.FromAssemblyNamed("EditPosts.PresentationServices").
                                   BasedOn(typeof(IBasePresentationService)).WithServiceDefaultInterfaces
                                   ().LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());

            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(
                    x => DbConfig.Configuration(connectionString).BuildSessionFactory()).
                    LifestyleSingleton());

            container.Register(
                Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).
                    LifestylePerWebRequest());
        }

        #endregion
    }
}