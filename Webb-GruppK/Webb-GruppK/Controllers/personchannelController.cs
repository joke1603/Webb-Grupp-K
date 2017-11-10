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
    public class personchannelController : Controller
    {
        private TvEntities db = new TvEntities();

        // GET: personchannel
        public ActionResult Index()
        {
            var personchannels = db.personchannels.Include(p => p.channel).Include(p => p.person);
            return View(personchannels.ToList());
        }

        // GET: personchannel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personchannel personchannel = db.personchannels.Find(id);
            if (personchannel == null)
            {
                return HttpNotFound();
            }
            return View(personchannel);
        }

        // GET: personchannel/Create
        public ActionResult Create()
        {
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name");
            ViewBag.FK_personid = new SelectList(db.people, "personid", "name");
            return View();
        }

        // POST: personchannel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personchannelid,FK_personid,FK_channelid")] personchannel personchannel)
        {
            if (ModelState.IsValid)
            {
                db.personchannels.Add(personchannel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", personchannel.FK_channelid);
            ViewBag.FK_personid = new SelectList(db.people, "personid", "name", personchannel.FK_personid);
            return View(personchannel);
        }

        // GET: personchannel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personchannel personchannel = db.personchannels.Find(id);
            if (personchannel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", personchannel.FK_channelid);
            ViewBag.FK_personid = new SelectList(db.people, "personid", "name", personchannel.FK_personid);
            return View(personchannel);
        }

        // POST: personchannel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personchannelid,FK_personid,FK_channelid")] personchannel personchannel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personchannel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_channelid = new SelectList(db.channels, "channelid", "name", personchannel.FK_channelid);
            ViewBag.FK_personid = new SelectList(db.people, "personid", "name", personchannel.FK_personid);
            return View(personchannel);
        }

        // GET: personchannel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personchannel personchannel = db.personchannels.Find(id);
            if (personchannel == null)
            {
                return HttpNotFound();
            }
            return View(personchannel);
        }

        // POST: personchannel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personchannel personchannel = db.personchannels.Find(id);
            db.personchannels.Remove(personchannel);
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
