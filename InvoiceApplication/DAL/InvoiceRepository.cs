using InvoiceApplication.Interfaces.Repository;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceApplication.DAL
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _context.Invoices.ToList();
        }

        public Invoice GetInvoiceByID(int invoiceId)
        {
            return _context.Invoices.Find(invoiceId);
        }

        public void InsertInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
        }

        public void DeleteInvoice(int invoiceId)
        {
            Invoice invoice = _context.Invoices.Find(invoiceId);
            _context.Invoices.Remove(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}