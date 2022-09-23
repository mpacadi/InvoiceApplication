namespace InvoiceApplication.Migrations
{
    using InvoiceApplication.Models.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InvoiceApplication.Models.ApplicationDbContext context)
        {
            var products = new List<Product>
            {
                new Product{Id = 1, Name="Pencile", Description="A wood pencile", Price=10.00m},
                new Product{Id = 2, Name="Pen", Description="A mechanical pencile", Price=15.00m},
                new Product{Id = 3, Name="Eraser", Description="A eraser for pencile", Price=5.00m}
            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var taxes = new List<InvoiceTax>
            {
                new InvoiceTax{Id=1, TaxName="HR", Tax=25m},
                new InvoiceTax{Id=2, TaxName="BIH", Tax=17m}
            };

            taxes.ForEach(s => context.InvoiceTaxes.AddOrUpdate(p => p.TaxName, s));
            context.SaveChanges();
        }
    }
}
