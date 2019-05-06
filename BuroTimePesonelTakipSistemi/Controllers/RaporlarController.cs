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
    public class RaporlarController : Controller
    {
        private Entities db = new Entities();

        // GET: Raporlar
        public ActionResult Index()
        {
            return View();
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
