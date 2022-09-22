using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceApplication.Interfaces;

namespace CroatianTax
{
    [Export("HR", typeof(ITaxCalculator))]
    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal price)
        {
            return price * 1.25m;
        }
    }
}
