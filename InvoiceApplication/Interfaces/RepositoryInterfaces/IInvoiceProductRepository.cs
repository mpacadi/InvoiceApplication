using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.RepositoryInterfaces
{
    internal interface IInvoiceProductRepository
    {
        IEnumerable<InvoiceProduct> GetInvoiceProducts();
        InvoiceProduct GetInvoiceProductByID(int invoiceProductId);
        void InsertInvoiceProduct(InvoiceProduct invoiceProduct);
        void DeleteInvoiceProduct(int invoiceProductId);
        void UpdateInvoiceProduct(InvoiceProduct invoiceProduct);
        void Save();
    }
}
