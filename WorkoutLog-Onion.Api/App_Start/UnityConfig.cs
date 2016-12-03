using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WorkoutLog_Onion.Application.Services;
using WorkoutLog_Onion.Domain.Services;
using WorkoutLog_Onion.Mongo;
using WorkoutLog_Onion.Server.Services;

namespace WorkoutLog_Onion.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IWorkoutService, WorkoutService>();
            container.RegisterType<IWorkoutRepository, WorkoutRepository>(new InjectionConstructor("mongodb://localhost/Workouts"));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}