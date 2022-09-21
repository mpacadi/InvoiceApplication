using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context;
        private GenericRepository<Invoice> invoiceRepository;
        private GenericRepository<InvoiceProduct> invoiceProductRepository;
        private GenericRepository<InvoiceTax> invoiceTaxRepository;
        private GenericRepository<Product> productRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<Invoice> InvoiceRepository
        {
            get
            {

                if (this.invoiceRepository == null)
                {
                    this.invoiceRepository = new GenericRepository<Invoice>(context);
                }
                return invoiceRepository;
            }
        }

        public GenericRepository<InvoiceProduct> InvoiceProductRepository
        {
            get
            {

                if (this.invoiceProductRepository == null)
                {
                    this.invoiceProductRepository = new GenericRepository<InvoiceProduct>(context);
                }
                return invoiceProductRepository;
            }
        }

        public GenericRepository<InvoiceTax> InvoiceTaxRepository
        {
            get
            {

                if (this.invoiceTaxRepository == null)
                {
                    this.invoiceTaxRepository = new GenericRepository<InvoiceTax>(context);
                }
                return invoiceTaxRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
