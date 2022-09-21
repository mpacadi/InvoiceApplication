using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceApplication.ViewModel
{
    public class ProductQuantityModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a quantity bigger than {1}")]
        public int Quantity { get; set; }
    }
}