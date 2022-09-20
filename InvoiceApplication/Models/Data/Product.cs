using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Models.Data
{
    public class Product
    {
        [ForeignKey("InvoiceProduct")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int InvoiceProductId { get; set; }
        public virtual InvoiceProduct InvoiceProduct { get; set; }
    }
}