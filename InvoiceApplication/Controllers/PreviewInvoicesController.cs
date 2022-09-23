using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceApplication.Models;
using InvoiceApplication.Models.Data;

namespace InvoiceApplication.Controllers
{
    public class PreviewInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuthorizedHome
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.InvoiceTax);
            return View(invoices.ToList());
        }

        // GET: AuthorizedHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
