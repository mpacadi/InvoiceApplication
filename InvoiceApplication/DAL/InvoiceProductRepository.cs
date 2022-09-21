using InvoiceApplication.Interfaces.RepositoryInterfaces;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceApplication.DAL
{
    public class InvoiceProductRepository : IInvoiceProductRepository
    {
        private ApplicationDbContext _context;

        public InvoiceProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<InvoiceProduct> GetInvoiceProducts()
        {
            return _context.InvoiceProducts.ToList();
        }

        public InvoiceProduct GetInvoiceProductByID(int invoiceProductId)
        {
            return _context.InvoiceProducts.Find(invoiceProductId);
        }

        public void InsertInvoiceProduct(InvoiceProduct invoiceProduct)
        {
            _context.InvoiceProducts.Add(invoiceProduct);
        }

        public void DeleteInvoiceProduct(int invoiceProductId)
        {
            InvoiceProduct invoiceProduct = _context.InvoiceProducts.Find(invoiceProductId);
            _context.InvoiceProducts.Remove(invoiceProduct);
        }

        public void UpdateInvoiceProduct(InvoiceProduct invoiceProduct)
        {
            _context.Entry(invoiceProduct).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}