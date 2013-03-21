using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using HistoryMvc.Common;

namespace HistoryMvc
{
    public static class UnityConfig
    {
        public static void Initialise(UnityConfigParameters parameters)
        {
            var container = BuildUnityContainer(parameters);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            FilterConfig.RegisterGlobalFilters(parameters.Filters, container);
        }

        private static IUnityContainer BuildUnityContainer(UnityConfigParameters parameters)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            //container.RegisterType<IUserProfileRepository, UserProfileRepository>();
            container.RegisterType<IPlanetRepository, PlanetRepository>();

            return container;
        }
    }

    public class UnityConfigParameters
    {
        public string ConnectionString { get; set; }
        public GlobalFilterCollection Filters { get; set; }
    }
}