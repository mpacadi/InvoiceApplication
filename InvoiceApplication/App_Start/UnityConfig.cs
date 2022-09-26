using InvoiceApplication.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using InvoiceApplication.Controllers;
using Unity.Injection;
using InvoiceApplication.Modules;
using InvoiceApplication.Interfaces.RepositoryInterfaces;
using InvoiceApplication.DAL;

namespace InvoiceApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ExtensionsModule>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}