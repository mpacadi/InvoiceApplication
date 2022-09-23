using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceApplication.DAL;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;

namespace InvoiceApplication.Controllers
{
    [Authorize]
    public class PreviewInvoicesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public PreviewInvoicesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: PreviewInvoices
        public ActionResult Index()
        {
            var invoices = _unitOfWork.InvoiceRepository.Get();
            return View(invoices.ToList());
        }

        // GET: PreviewInvoices/Details/5
        public ActionResult Details(int? id)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
