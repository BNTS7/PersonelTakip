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
    public class LoginController : Controller
    {
        private Entities db = new Entities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        
       [HttpPost]
        public ActionResult Login(BuroTimePesonelTakipSistemi.Models.Admin_tbl userModel)
        {

            var user = db.Admin_tbl.Where(x => x.Name == userModel.Name && x.Password == userModel.Password).FirstOrDefault();
            if(user == null)
            {       
                return View("Index",userModel);
            }
            else
            {
                Session["ID"] = "userModel.ID";
                Session["Name"] = "userModel.Name";
                return RedirectToAction("Index", "Home");
            }
            
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
