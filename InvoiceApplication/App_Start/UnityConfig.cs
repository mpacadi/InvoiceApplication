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
using InvoiceApplication.Services;
using InvoiceApplication.Interfaces.Services;
using InvoiceApplication.Interfaces.Modules;

namespace InvoiceApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IInvoiceService, InvoiceService>();
            container.RegisterType<IExtensionModule, ExtensionModule>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}