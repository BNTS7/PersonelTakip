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
    public class PersonelController : Controller
    {
        private Entities db = new Entities();

        // GET: Personel
        public ActionResult Index()
        {
            var personel_tbl = db.Personel_tbl.Include(p => p.Department_tbl);
            return View(personel_tbl.ToList());
        }

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel_tbl personel_tbl = db.Personel_tbl.Find(id);
            if (personel_tbl == null)
            {
                return HttpNotFound();
            }
            return View(personel_tbl);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            ViewBag.D_Id = new SelectList(db.Department_tbl, "ID", "Department");
            return View();
        }

        // POST: Personel/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sicil_No,Name,Surname,D_Id,Position,Staff,Address,Phone")] Personel_tbl personel_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Personel_tbl.Add(personel_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.D_Id = new SelectList(db.Department_tbl, "ID", "Department", personel_tbl.D_Id);
            return View(personel_tbl);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel_tbl personel_tbl = db.Personel_tbl.Find(id);
            if (personel_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.D_Id = new SelectList(db.Department_tbl, "ID", "Department", personel_tbl.D_Id);
            return View(personel_tbl);
        }

        // POST: Personel/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sicil_No,Name,Surname,D_Id,Position,Staff,Address,Phone")] Personel_tbl personel_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.D_Id = new SelectList(db.Department_tbl, "ID", "Department", personel_tbl.D_Id);
            return View(personel_tbl);
        }

        // GET: Personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel_tbl personel_tbl = db.Personel_tbl.Find(id);
            if (personel_tbl == null)
            {
                return HttpNotFound();
            }
            return View(personel_tbl);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel_tbl personel_tbl = db.Personel_tbl.Find(id);
            db.Personel_tbl.Remove(personel_tbl);
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
