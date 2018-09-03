using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gfi_test_landing;
using gfi_test_landing.Models;

namespace gfi_test_landing.Controllers
{
    public class ReportsController : Controller
    {
        private testLandingEntities db = new testLandingEntities();

        // GET: Reports
        public ActionResult Index()
        {
            try
            {
                // Entity Framework can't call methods on join and LINQ syntax
                // Convert the Session UserID to a String
                int id_project = int.Parse(Session["projectId"].ToString());

                var idReport = db.Report.Select(r => r.id).ToList();

                // Create a List with ProjectViewModel objects to be sent to the view
   
                var ReportList = (from r in db.Report
                                      join rc in db.ReportCollection on r.id equals rc.report_id
                                      join p in db.Project on rc.project_id equals p.id
                                      where p.id == id_project
                                      select new ReportViewModel { Id = r.id, DateStart = r.date_start.ToString(), DateEnd = r.date_end.ToString(), Status = r.status, GeneralMessage = r.general_message }).Distinct().ToList();
              
                // Return the list to the View
                return View(ReportList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        private string subtractDate(string end, string start)
        {
            DateTime endDate = DateTime.Parse(end);
            DateTime startDate = DateTime.Parse(start);
            TimeSpan difference = endDate.Subtract(startDate);
            return difference.ToString();
        }

        public ActionResult Details(int? id)
        {
            try
            {
                // Entity Framework can't call methods on join and LINQ syntax
                // Convert the Session UserID to a String
                int id_project = int.Parse(Session["projectId"].ToString());

                // Create a List with ProjectViewModel objects to be sent to the view
                var ReportList = (from rc in db.ReportCollection
                                  where rc.report_id == id
                                  select new SingleTestReportModel {Author= rc.author, ProjectId =id_project, Name = rc.test_name, Id = rc.id, DateStart = rc.date_start.ToString(), DateEnd = rc.date_end.ToString(), Status = rc.status, GeneralMessage = rc.general_message }).ToList();

                // Return the list to the View
                return View(ReportList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET: Reports/SingleTestReport/5
        public ActionResult SingleTestReport(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                // Entity Framework can't call methods on join and LINQ syntax
                // Convert the Session UserID to a String
                // Create a List with SingleTestReportModel objects to be sent to the view
                ReportCollection rc = db.ReportCollection.Find(id);
                // Return the list to the View
                return View(rc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.id_batteryTest = new SelectList(db.BatteryTest, "id", "status");
            ViewBag.id_machine = new SelectList(db.Machine, "id", "cpu");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_start,date_end,status,general_message,error_message,warning_message,error_type,logs,id_batteryTest,id_machine,report_test_collection_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Report.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_batteryTest = new SelectList(db.BatteryTest, "id", "status", report.id_batteryTest);
            ViewBag.id_machine = new SelectList(db.Machine, "id", "cpu", report.id_machine);
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Report.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_batteryTest = new SelectList(db.BatteryTest, "id", "status", report.id_batteryTest);
            ViewBag.id_machine = new SelectList(db.Machine, "id", "cpu", report.id_machine);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_start,date_end,status,general_message,error_message,warning_message,error_type,logs,id_batteryTest,id_machine,report_test_collection_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_batteryTest = new SelectList(db.BatteryTest, "id", "status", report.id_batteryTest);
            ViewBag.id_machine = new SelectList(db.Machine, "id", "cpu", report.id_machine);
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Report.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Report.Find(id);
            db.Report.Remove(report);
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
