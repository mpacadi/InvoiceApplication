using InvoiceApplication.Models.Data;
using InvoiceApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.Services
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceTax> GetAllTaxes();
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Invoice> GetAllInvoices();
        Invoice CreateInvoice(AddInvoiceModel addInvoiceModel, string user);
        Invoice GetByIdInvoice(int id);
        void DeleteInvoice(int id);
        void AddInvoice(Invoice invoice);
        IEnumerable<ErrorResponse> GetAllValidationErrors(AddInvoiceModel model);
    }
}
