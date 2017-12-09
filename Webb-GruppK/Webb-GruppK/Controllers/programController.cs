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
    public class programController : Controller
    {
        private TvEntities db = new TvEntities();

        // GET: program
        public ActionResult Index()
        {
           
            var programs = db.programs.Include(p => p.channel);
            return View(programs.ToList());
        }

        // GET: program/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: program/Create
        public ActionResult Create()
        {
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name");
            return View();
        }

        // POST: program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "programid,name,description,time_from,time_to,genre,FK_channelid,date")] program program)
        {
            if (ModelState.IsValid)
            {
                db.programs.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", program.FK_channelid);
            return View(program);
        }

        // GET: program/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", program.FK_channelid);
            return View(program);
        }

        // POST: program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "programid,name,description,time_from,time_to,genre,FK_channelid,date")] program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", program.FK_channelid);
            return View(program);
        }

        // GET: program/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            program program = db.programs.Find(id);
            db.programs.Remove(program);
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
