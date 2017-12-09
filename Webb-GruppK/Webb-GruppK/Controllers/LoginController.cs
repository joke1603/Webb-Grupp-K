using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webb_GruppK.Models;

namespace Webb_GruppK.Controllers
{
    public class LoginController : Controller
    {
        TvEntities db = new TvEntities();
        // GET: Login
        public ActionResult Login(person User)
        {
            var Usr = db.people.Where(u => u.email == User.email && u.password == User.password).FirstOrDefault();
            if (Usr == null)
            {
                return View("Login");
            }
            else
            {
                Session["id"] = Usr.personid;
                Session["email"] = Usr.email;
                Session["admin"] = Usr.role;
                return RedirectToAction("Index", "program");
            }
        }

        public ActionResult Logout()
        {
            int UsrId = (int)Session["id"];
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}