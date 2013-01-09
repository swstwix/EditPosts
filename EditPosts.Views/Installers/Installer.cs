using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EditPosts.Domain.Repositories;
using EditPosts.PresentationServices.Services;
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

            container.Register(Classes
                .FromAssemblyNamed("EditPosts.Dapper")
                .BasedOn<IRepository>()
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest()
                .Configure(x => Parameter.ForKey("connectionString").Eq(connectionString)));

            container.Register(AllTypes.FromAssemblyNamed("EditPosts.PresentationServices").
                                   BasedOn(typeof(IBasePresentationService)).WithServiceDefaultInterfaces
                                   ().LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }

        #endregion
    }
}