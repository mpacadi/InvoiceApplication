using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceApplication.ViewModel
{
    public class AddInvoiceModel
    {
        public DateTime InvoicePayday { get; set; }
        public IEnumerable<ProductQuantityModel> ProductQuantitys { get; set; }
        public string CustomerName { get; set; }
        public int Tax { get; set; }  
    }
}