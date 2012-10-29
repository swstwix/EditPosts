using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EditPosts.Db;
using EditPosts.Domain.Repositories;
using EditPosts.PresentationServices.Services;
using NHibernate;

namespace EditPosts.Views.Installers
{
    public class Installer : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromAssemblyNamed("EditPosts.Db").BasedOn(typeof (IRepository)).WithServiceDefaultInterfaces().
                    LifestyleSingleton());

            container.Register(
                Classes.FromThisAssembly().BasedOn<IRepository>().LifestyleSingleton());

            container.Register(AllTypes.FromAssemblyNamed("EditPosts.PresentationServices").
                                   BasedOn(typeof (IBasePresentationService)).WithServiceDefaultInterfaces
                                   ().LifestyleSingleton());

            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());

            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(
                    x => DbConfig.Configuration.BuildSessionFactory()).
                    LifestyleSingleton());

            container.Register(
                Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).
                    LifestyleTransient());
        }

        #endregion
    }
}