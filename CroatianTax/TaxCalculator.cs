using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceApplication.Interfaces;

namespace CroatianTax
{
    public class TaxCalculator : ITaxCalculator
    {
        [Export("HR", typeof(ITaxCalculator))]
        public decimal CalculateTax(decimal price)
        {
            return price * 1.25m;
        }
    }
}
