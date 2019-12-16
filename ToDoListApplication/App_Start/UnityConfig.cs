using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using DAL.IRepository;
using DAL.Repository;
using Services;

namespace ToDoListApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<ITaskItemRepository, TaskItemRepository>();
            container.RegisterType<ITaskItemService, TaskItemService>();
        }
    }
}