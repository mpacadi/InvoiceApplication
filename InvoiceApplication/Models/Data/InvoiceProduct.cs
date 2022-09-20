using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Models.Data
{
    public class InvoiceProduct
    {
        public int Id { get; set; }
        public int SellCount { get; set; }
        public decimal PriceTaxFree { get; set; }
        public decimal TotalPriceTaxFree { get; set; }
        public virtual Product Product { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }       

    }
}