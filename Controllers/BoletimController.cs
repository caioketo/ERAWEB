using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERAWeb.Models;

namespace ERAWeb.Controllers
{
    public class BoletimController : Controller
    {
        private ERAContext db = new ERAContext();

        // GET: Boletim
        public ActionResult Index()
        {
            return View(db.BoletimModels.ToList());
        }

        // GET: Boletim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoletimModel boletimModel = db.BoletimModels.Find(id);
            if (boletimModel == null)
            {
                return HttpNotFound();
            }
            return View(boletimModel);
        }

        // GET: Boletim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boletim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataExclusao,DataCriacao,DataAlteracao")] BoletimModel boletimModel)
        {
            if (ModelState.IsValid)
            {
                db.BoletimModels.Add(boletimModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boletimModel);
        }

        // GET: Boletim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoletimModel boletimModel = db.BoletimModels.Find(id);
            if (boletimModel == null)
            {
                return HttpNotFound();
            }
            return View(boletimModel);
        }

        // POST: Boletim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataExclusao,DataCriacao,DataAlteracao")] BoletimModel boletimModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boletimModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boletimModel);
        }

        // GET: Boletim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoletimModel boletimModel = db.BoletimModels.Find(id);
            if (boletimModel == null)
            {
                return HttpNotFound();
            }
            return View(boletimModel);
        }

        // POST: Boletim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoletimModel boletimModel = db.BoletimModels.Find(id);
            db.BoletimModels.Remove(boletimModel);
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
