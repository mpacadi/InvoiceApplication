using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.Interfaces.Repository
{
    internal interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserByID(string userId);
        void InsertUser(ApplicationUser invoice);
        void DeleteUser(string userId);
        void UpdateUser(ApplicationUser user);
        void Save();
    }
}
