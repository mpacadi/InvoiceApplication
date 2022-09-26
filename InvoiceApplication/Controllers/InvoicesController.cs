using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using InvoiceApplication.Interfaces.Services;
using InvoiceApplication.Models.Data;
using InvoiceApplication.ViewModel;
using log4net;

namespace InvoiceApplication.Controllers
{
    [Authorize]
    public class InvoicesController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
