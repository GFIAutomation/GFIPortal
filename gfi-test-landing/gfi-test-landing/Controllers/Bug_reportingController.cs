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
    public class Bug_reportingController : Controller
    {
        private testLandingEntities db = new testLandingEntities();

        // GET: Bug_reporting
        public ActionResult Index()
        {
            return View(db.Bug_reporting.ToList());
        }

        // GET: Bug_reporting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug_reporting bug_reporting = db.Bug_reporting.Find(id);
            if (bug_reporting == null)
            {
                return HttpNotFound();
            }
            return View(bug_reporting);
        }

        // GET: Bug_reporting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bug_reporting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Current_behaviour,Expected_behaviour,Bug_reporting_collection_id,Browser,Operating_system")] Bug_reporting bug_reporting, FormCollection fm)
        {
            String[] steps = new String[20];
            for (int i = 0; i <= int.Parse(fm.Get("Steps_count")); i++)
            {
                steps[i] = fm.Get("Step_" + i);
            }

            if (ModelState.IsValid)
            {
                db.Bug_reporting.Add(bug_reporting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bug_reporting);
        }

        // GET: Bug_reporting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug_reporting bug_reporting = db.Bug_reporting.Find(id);
            if (bug_reporting == null)
            {
                return HttpNotFound();
            }
            return View(bug_reporting);
        }

        // POST: Bug_reporting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Current_behaviour,Expected_behaviour,Bug_reporting_collection_id,Browser,Operating_system,Date")] Bug_reporting bug_reporting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bug_reporting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bug_reporting);
        }

        // GET: Bug_reporting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug_reporting bug_reporting = db.Bug_reporting.Find(id);
            if (bug_reporting == null)
            {
                return HttpNotFound();
            }
            return View(bug_reporting);
        }

        // POST: Bug_reporting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug_reporting bug_reporting = db.Bug_reporting.Find(id);
            db.Bug_reporting.Remove(bug_reporting);
            db.SaveChanges();
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
