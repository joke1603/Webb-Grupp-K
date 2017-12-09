using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webb_GruppK.Models;

namespace Webb_GruppK.Controllers
{
    public class HomeController : Controller
    {
        TvEntities db = new TvEntities();

        //GET: Home
        public ActionResult Index(string searchString, string genreSearch)
        {
            var program = db.programs.Include(p => p.channel);
            if (!String.IsNullOrEmpty(searchString))
            {
                program = program.Where(p => p.name.Contains(searchString) || p.genre.Contains(searchString) || p.channel.name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(genreSearch))
            {
                program = program.Where(p => p.genre.Contains(genreSearch));
            }
            return View(program.ToList());
            //var program = db.programs.Include(p => p.channel);
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    program = program.Where(p => p.name.Contains(searchString) || p.genre.Contains(searchString) || p.channel.name.Contains(searchString));
            //}
            //if (!string.IsNullOrEmpty(genreSearch))
            //{
            //    program = program.Where(p => p.genre.Contains(genreSearch));
            //}
            //var programs = db.programs.Include(p => p.channel);
            //return View(programs.ToList());


            //var pro = db.programs.Include(p => p.channel);
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    pro = pro.Where(p => p.name.Contains(searchString) || p.genre.Contains(searchString) || p.channel.name.Contains(searchString));             
            //}
            //if (!string.IsNullOrEmpty(genreSearch))
            //{
            //    pro = pro.Where(p => p.genre.Contains(genreSearch));
            //}
            ////ViewBag.Channels = db.channels.OrderBy(c => c.name).ToList();
            //return View(pro.ToList()); //.Include("channel")
        }

        [HttpGet]
        public ActionResult Person()
        {
            person newPerson = new person();
            return View(newPerson);
        }

        [HttpPost]
        public ActionResult Account(person newPerson)
        {
            if (ModelState.IsValid)
            {
                db.people.Add(newPerson);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Login", "Login", new person());
        }

        public ActionResult MyPage(person User)
        {
            var Usr = Convert.ToInt32(Session["id"]);
            if (Session["id"] != null)
            {
                ViewBag.favoritelist = db.personchannels.Where(x => x.FK_personid == Usr).Select(z => z.FK_channelid).ToList();


                return View(db.programs.Include("channel").ToList());
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult chanlist()
        {
            ViewBag.addfavorite = db.channels.Select(f => new SelectListItem { Value = f.channelid.ToString(), Text = f.name });
            personchannel favorite = new personchannel();
            return View(favorite);
        }
        [HttpPost]
        public ActionResult chanlist(personchannel favorite)
        {
            var Usr = Convert.ToInt32(Session["id"]);
            try
            {
                personchannel newfavorite = new personchannel();
                newfavorite.FK_channelid = favorite.FK_channelid;
                newfavorite.FK_personid = Usr;
                db.personchannels.Add(newfavorite);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return RedirectToAction("MyPage", "Home");
        }

        public ActionResult addfavorite()
        {
            return View("chanlist");
        }

    }
}