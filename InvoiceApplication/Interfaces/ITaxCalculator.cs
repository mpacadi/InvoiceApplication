using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal price);
    }
}
