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
        private readonly ApplicationDbContext _context;
        private GenericRepository<Invoice> invoiceRepository;
        private GenericRepository<InvoiceProduct> invoiceProductRepository;
        private GenericRepository<InvoiceTax> invoiceTaxRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<ApplicationUser> userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public GenericRepository<Invoice> InvoiceRepository
        {
            get
            {

                if (this.invoiceRepository == null)
                {
                    this.invoiceRepository = new GenericRepository<Invoice>(_context);
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
                    this.invoiceProductRepository = new GenericRepository<InvoiceProduct>(_context);
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
                    this.invoiceTaxRepository = new GenericRepository<InvoiceTax>(_context);
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
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        public GenericRepository<ApplicationUser> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<ApplicationUser>(_context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
