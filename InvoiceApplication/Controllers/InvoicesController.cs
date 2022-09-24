using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceApplication.DAL;
using InvoiceApplication.Interfaces;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using InvoiceApplication.Modules;
using InvoiceApplication.ViewModel;
using Microsoft.AspNet.Identity;
using Unity;

namespace InvoiceApplication.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ExtensionsModule _extensions;
        private ApplicationDbContext db = new ApplicationDbContext();

        public InvoicesController(ApplicationDbContext context, ExtensionsModule extensionsModule)
        {
            _unitOfWork = new UnitOfWork(context);
            _extensions = extensionsModule;
        }



        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = _unitOfWork.InvoiceRepository.Get();
            return View(invoices.ToList());
        }


        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.TaxesIds = _unitOfWork.InvoiceTaxRepository.Get();
            return View();
        }

        // POST: Invoices/AddNewInvoiceProduct
        public ActionResult AddNewInvoiceProduct()
        {
            var ProductQuantity = new ProductQuantityModel();
            ViewBag.Products =  _unitOfWork.ProductRepository.Get();
            return PartialView("PartialViewProduct", ProductQuantity);
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddInvoiceModel invoice)
        {
            if (ModelState.IsValid)
            {
                Invoice lastInvoice = _unitOfWork.InvoiceRepository.Get().LastOrDefault();

                ICollection<InvoiceProduct> invoiceProducts = GenerateInvoiceProducts(invoice.ProductQuantitys);

                decimal totalTaxFree = invoiceProducts.Sum(x => x.TotalPriceTaxFree);

                string taxName = _unitOfWork.InvoiceTaxRepository.GetByID(invoice.Tax).TaxName;

                Invoice newInvoice = new Invoice()
                {
                    InvoiceNumber = lastInvoice != null ? lastInvoice.InvoiceNumber + 1 : 0,
                    InvoiceCreated = DateTime.Now,
                    InvoicePayday = invoice.InvoicePayday,
                    InvoiceProducts = invoiceProducts,
                    TotalTaxFree = totalTaxFree,
                    TotalTax = _extensions.GetExtension<ITaxCalculator>(taxName).CalculateTax(totalTaxFree),
                    CustomerName = invoice.CustomerName,
                    InvoiceCreator = User.Identity.Name,
                    InvoiceTaxId = invoice.Tax
                };


                _unitOfWork.InvoiceRepository.Insert(newInvoice);
                _unitOfWork.Save();

             
            }

            return RedirectToAction("Index");
        }

        private ICollection<InvoiceProduct> GenerateInvoiceProducts(IEnumerable<ProductQuantityModel> productQuantities)
        {
            var invoiceProducts = new List<InvoiceProduct>();
            var deduplicatedProductQuantities = productQuantities.GroupBy(x => x.ProductId).Select(x => new ProductQuantityModel()
            {
                ProductId = x.Key,
                Quantity = x.Sum(c => c.Quantity)
            });

            foreach (var productQuantity in deduplicatedProductQuantities)
            {
                
                var product = _unitOfWork.ProductRepository.GetByID(productQuantity.ProductId);
                invoiceProducts.Add(new InvoiceProduct()
                {
                    SellCount = productQuantity.Quantity,
                    PriceTaxFree = product.Price,
                    TotalPriceTaxFree = product.Price * productQuantity.Quantity,
                    ProductId = productQuantity.ProductId
                });
            }

            return invoiceProducts;
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = _unitOfWork.InvoiceRepository.GetByID(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = _unitOfWork.InvoiceRepository.GetByID(id);
            _unitOfWork.InvoiceRepository.Delete(invoice);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
