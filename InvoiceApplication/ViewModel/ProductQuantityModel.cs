using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceApplication.ViewModel
{
    public class ProductQuantityModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}