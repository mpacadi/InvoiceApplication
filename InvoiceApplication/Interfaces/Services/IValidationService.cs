using InvoiceApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace InvoiceApplication.Interfaces.Services
{
    public interface IValidationService<T> where T : class
    {
        IEnumerable<ErrorResponse> GetAllValidationErrors(T model);
    }
}
