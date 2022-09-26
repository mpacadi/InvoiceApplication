using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceApplication.Interfaces.Modules;

namespace BosnianTax
{
    [Export("BIH", typeof(ITaxCalculator))]
    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal price)
        {
            return price * 1.17m;
        }
    }
}
