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
    public class HareketlerController : Controller
    {
        private Entities db = new Entities();

        // GET: Hareketler
        public ActionResult Index()
        {
            var action_tbl = db.Action_tbl.Include(a => a.Personel_tbl);
            return View(action_tbl.ToList());
        }

        // GET: Hareketler/Create
        public ActionResult Create()
        {
            ViewBag.P_Id = new SelectList(db.Personel_tbl, "ID", "Name");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,P_Id,Checkin_Time,Checkout_Time,Shift,Job_Rotation,Description,Cadre,Dater")] Action_tbl action_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Action_tbl.Add(action_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.P_Id = new SelectList(db.Personel_tbl, "ID", "Name", action_tbl.P_Id);
            return View(action_tbl);
        }

        // GET: Hareketler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action_tbl action_tbl = db.Action_tbl.Find(id);
            if (action_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.P_Id = new SelectList(db.Personel_tbl, "ID", "Name", action_tbl.P_Id);
            return View(action_tbl);
        }

        // POST: Hareketler/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,P_Id,Checkin_Time,Checkout_Time,Shift,Job_Rotation,Description,Cadre,Dater")] Action_tbl action_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(action_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.P_Id = new SelectList(db.Personel_tbl, "ID", "Name", action_tbl.P_Id);
            return View(action_tbl);
        }

        // GET: Hareketler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action_tbl action_tbl = db.Action_tbl.Find(id);
            if (action_tbl == null)
            {
                return HttpNotFound();
            }
            return View(action_tbl);
        }

        // POST: Hareketler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Action_tbl action_tbl = db.Action_tbl.Find(id);
            db.Action_tbl.Remove(action_tbl);
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
