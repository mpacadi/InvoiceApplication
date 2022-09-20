using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Models.Data
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceCreated { get; set; }
        public DateTime InvoicePayday { get; set; }
        public decimal TotalTaxFree { get; set; }
        public decimal TotalTax { get; set; }
        public string CustomerName { get; set; }

        public virtual ApplicationUser InvoiceCreator { get; set; }
        public int InvoiceTaxId { get; set; }
        public virtual InvoiceTax InvoiceTax { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}