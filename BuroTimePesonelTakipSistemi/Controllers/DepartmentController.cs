using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuroTimePesonelTakipSistemi.Models;

namespace BuroTimePesonelTakipSistemi.Controllers
{
    public class DepartmentController : Controller
    {
        private Entities db = new Entities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department_tbl.ToList());
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Department")] Department_tbl department_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Department_tbl.Add(department_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department_tbl);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_tbl department_tbl = db.Department_tbl.Find(id);
            if (department_tbl == null)
            {
                return HttpNotFound();
            }
            return View(department_tbl);
        }

        // POST: Department/Edit/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Department")] Department_tbl department_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department_tbl);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_tbl department_tbl = db.Department_tbl.Find(id);
            if (department_tbl == null)
            {
                return HttpNotFound();
            }
            return View(department_tbl);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_tbl department_tbl = db.Department_tbl.Find(id);
            db.Department_tbl.Remove(department_tbl);
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
