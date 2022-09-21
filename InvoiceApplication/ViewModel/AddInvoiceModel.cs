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
        [Required]
        public DateTime InvoicePayday { get; set; }

        [Required(ErrorMessage = "Choose one or more options")]
        public IEnumerable<ProductQuantityModel> ProductQuantitys { get; set; }

        [Required]
        [StringLength(32)]
        public string CustomerName { get; set; }
        public int Tax { get; set; }  
    }
}