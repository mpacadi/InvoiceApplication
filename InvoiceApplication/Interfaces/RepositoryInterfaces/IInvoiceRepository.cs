using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.RepositoryInterfaces
{
    internal interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoiceByID(int invoiceId);
        void InsertInvoice(Invoice invoice);
        void DeleteInvoice(int invoiceId);
        void UpdateInvoice(Invoice invoice);
        void Save();
    }
}
