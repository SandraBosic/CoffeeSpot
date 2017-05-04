using CoffeeSpot.Controllers;
using CoffeeSpot.Data;
using CoffeeSpot.Infrastructure;
using CoffeeSpot.Repositories;
using CoffeeSpot.Repositories.Interfaces;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace CoffeeSpot.App_Start
{
    public static class IoCConfigurator
    {
        public static void ConfigureUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            Register(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ICoffeeSpotRepository, CoffeeSpotRepository>();
            container.RegisterType<ICoffeeSpotContext, CoffeeSpotContext>();
        }
    }
}