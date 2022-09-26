using System;
using System.CodeDom;
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
using FluentValidation.Results;
using InvoiceApplication.DAL;
using InvoiceApplication.Interfaces.Modules;
using InvoiceApplication.Interfaces.RepositoryInterfaces;
using InvoiceApplication.Interfaces.Services;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using InvoiceApplication.Modules;
using InvoiceApplication.Validators;
using InvoiceApplication.ViewModel;
using log4net;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity;

namespace InvoiceApplication.Controllers
{
    [Authorize]
    public class InvoicesController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IInvoiceService _service;

        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }



        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = _service.GetAllInvoices();
            return View(invoices);
        }


        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.TaxesIds = _service.GetAllTaxes();
            return View();
        }

        // POST: Invoices/AddNewInvoiceProduct
        public ActionResult AddNewInvoiceProduct()
        {
            var ProductQuantity = new ProductQuantityModel();
            ViewBag.Products =  _service.GetAllProducts();
            return PartialView("PartialViewProduct", ProductQuantity);
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddInvoiceModel addInvoiceModel)
        {
            if (ModelState.IsValid)
            {
                Invoice newInvoice = _service.CreateInvoice(addInvoiceModel, User.Identity.Name);

                _service.AddInvoice(newInvoice);
            }
            else
            {
                TempData["err"] = _service.GetAllValidationErrors(addInvoiceModel);
                return RedirectToAction("BadRequest", "Error");
            }

            return RedirectToAction("Index");
        }

        

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                var errMsg = "Invoice Id is not provided in Get Delete request";
                _logger.Error(errMsg);
                TempData["err"] = new List<ErrorResponse>{ new ErrorResponse("Id Missing", errMsg)};
                return RedirectToAction("BadRequest", "Error");
            }
            Invoice invoice = _service.GetByIdInvoice((int) id);
            if (invoice == null)
            {
                _logger.Error("Invoice with id " + id + " not found");
                return RedirectToAction("NotFound", "Error");
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.DeleteInvoice(id);
            return RedirectToAction("Index");
        }
    }
}
