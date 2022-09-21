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
    public class InvoiceTaxRepository : IInvoiceTaxRepository
    {
        private ApplicationDbContext _context;

        public InvoiceTaxRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<InvoiceTax> GetInvoiceTaxes()
        {
            return _context.InvoiceTaxes.ToList();
        }

        public InvoiceTax GetInvoiceTaxByID(int invoiceTaxId)
        {
            return _context.InvoiceTaxes.Find(invoiceTaxId);
        }

        public void InsertInvoiceTax(InvoiceTax invoiceTax)
        {
            _context.InvoiceTaxes.Add(invoiceTax);
        }

        public void DeleteInvoiceTax(int invoiceTaxId)
        {
            InvoiceTax invoiceTax = _context.InvoiceTaxes.Find(invoiceTaxId);
            _context.InvoiceTaxes.Remove(invoiceTax);
        }

        public void UpdateInvoiceTax(InvoiceTax invoiceTax)
        {
            _context.Entry(invoiceTax).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}