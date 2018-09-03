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
    public class StepsController : Controller
    {
        private testLandingEntities db = new testLandingEntities();

        // GET: Steps
        public ActionResult Index()
        {
            var step = db.Step.Include(s => s.Action).Include(s => s.Object);
            return View(step.ToList());
        }

        // GET: Steps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Step.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // GET: Steps/Create
        public ActionResult Create()
        {
            ViewBag.id_action = new SelectList(db.Action, "id", "name");
            ViewBag.id_object = new SelectList(db.Object, "id", "name");
            return View();
        }

        // POST: Steps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_action,id_object,last_update,status")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Step.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_action = new SelectList(db.Action, "id", "name", step.id_action);
            ViewBag.id_object = new SelectList(db.Object, "id", "name", step.id_object);
            return View(step);
        }

        // GET: Steps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Step.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_action = new SelectList(db.Action, "id", "name", step.id_action);
            ViewBag.id_object = new SelectList(db.Object, "id", "name", step.id_object);
            return View(step);
        }

        // POST: Steps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_action,id_object,last_update,status")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Entry(step).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_action = new SelectList(db.Action, "id", "name", step.id_action);
            ViewBag.id_object = new SelectList(db.Object, "id", "name", step.id_object);
            return View(step);
        }

        // GET: Steps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Step.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Step step = db.Step.Find(id);
            db.Step.Remove(step);
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
