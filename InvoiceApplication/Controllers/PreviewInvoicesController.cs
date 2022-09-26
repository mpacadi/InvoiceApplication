using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using InvoiceApplication.DAL;
using InvoiceApplication.Interfaces.Repository;
using InvoiceApplication.Interfaces.Services;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;
using InvoiceApplication.ViewModel;
using log4net;


namespace InvoiceApplication.Controllers
{
    [Authorize]
    public class PreviewInvoicesController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IInvoiceService _service;

        public PreviewInvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        // GET: PreviewInvoices
        public ActionResult Index()
        {
            var invoices = _service.GetAllInvoices();
            return View(invoices);
        }

        // GET: PreviewInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                var errMsg = "Invoice Id is not provided in Get Delete request";
                _logger.Error(errMsg);
                TempData["err"] = new List<ErrorResponse> { new ErrorResponse("Id Missing", errMsg) };
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
    }
}
