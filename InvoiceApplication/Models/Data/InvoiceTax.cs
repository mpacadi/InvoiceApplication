﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Models.Data
{
    public class InvoiceTax
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public decimal Tax { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}