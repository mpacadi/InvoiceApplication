using InvoiceApplication.DAL;
using InvoiceApplication.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace InvoiceApplication.Modules
{
    public class ExtensionsModule : IExtensionModule
    {
        public AggregateCatalog catalog { get; set; }
        public CompositionContainer container { get; set; }
        public ExtensionsModule()
        {
            catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(ConfigurationManager.AppSettings["ExtensionsPath"]));
            container = new CompositionContainer(catalog);
        }

        public T GetExtension<T>(string contractName)
        {
            return container.GetExport<T>(contractName).Value;
        }
    }
}