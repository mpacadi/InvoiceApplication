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
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductByID(int productId)
        {
            return _context.Products.Find(productId);
        }

        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.Find(productId);
            _context.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}