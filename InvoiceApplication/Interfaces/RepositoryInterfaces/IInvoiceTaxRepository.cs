using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.RepositoryInterfaces
{
    internal interface IInvoiceTaxRepository
    {
        IEnumerable<InvoiceTax> GetInvoiceTaxes();
        InvoiceTax GetInvoiceTaxByID(int invoiceTaxId);
        void InsertInvoiceTax(InvoiceTax invoiceTax);
        void DeleteInvoiceTax(int invoiceTaxId);
        void UpdateInvoiceTax(InvoiceTax invoiceTax);
        void Save();
    }
}
