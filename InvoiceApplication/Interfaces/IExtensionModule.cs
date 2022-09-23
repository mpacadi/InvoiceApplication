using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces
{
    internal interface IExtensionModule
    {
        T GetExtension<T>(string contractName);
    }
}
