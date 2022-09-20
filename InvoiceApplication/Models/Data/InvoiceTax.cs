using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Models.Data
{
    public class InvoiceTax
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public decimal Tax { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}