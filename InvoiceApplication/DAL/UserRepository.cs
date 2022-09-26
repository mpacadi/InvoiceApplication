using InvoiceApplication.Interfaces.Repository;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceApplication.DAL
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUserByID(string userId)
        {
            return _context.Users.Find(userId);
        }

        public void InsertUser(ApplicationUser user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(string userId)
        {
            ApplicationUser user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}