using InvoiceApplication.DAL;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Invoice> InvoiceRepository { get; }
        GenericRepository<InvoiceProduct> InvoiceProductRepository { get; }
        GenericRepository<InvoiceTax> InvoiceTaxRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<ApplicationUser> UserRepository { get; }

        void Save();
    }
}
