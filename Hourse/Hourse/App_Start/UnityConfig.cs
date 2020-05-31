using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Hourse.Models.UnitOfWorks;
using Hourse.Services;

namespace Hourse
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHomeService, HomeService>();
            container.RegisterType<IHomeUnitOfWork, HomeUnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}