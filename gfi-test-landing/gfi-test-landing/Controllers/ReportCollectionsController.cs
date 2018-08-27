using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gfi_test_landing;

namespace gfi_test_landing.Controllers
{
    public class ReportCollectionsController : Controller
    {
        private testLandingEntities db = new testLandingEntities();

        // GET: ReportCollections
        public ActionResult Index()
        {
            return View(db.ReportCollection.ToList());
        }

        // GET: ReportCollections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportCollection reportCollection = db.ReportCollection.Find(id);
            if (reportCollection == null)
            {
                return HttpNotFound();
            }
            return View(reportCollection);
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
