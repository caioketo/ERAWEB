using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERAWeb.Models;
using Newtonsoft.Json;

namespace ERAWeb.Controllers
{
    public class AvisoController : Controller
    {
        private ERAContext db = new ERAContext();

        // GET: /Aviso/
        public ActionResult Index()
        {
            return View(db.AvisoModels.OrderByDescending(a => a.Id).ToList());
        }

        // GET: /Aviso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoModel avisomodel = db.AvisoModels.Find(id);
            if (avisomodel == null)
            {
                return HttpNotFound();
            }
            return View(avisomodel);
        }

        // GET: /Aviso/Create
        public ActionResult Create()
        {
            ViewBag.Arquivos = new SelectList(db.ArquivoModels, "Id", "Arquivo");
            ViewBag.Turmas = new SelectList(db.TurmaModels, "Id", "Display");
            return View();
        }

        // POST: /Aviso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Aviso,DataExclusao,DataCriacao,DataAlteracao")] AvisoModel avisomodel)
        public ActionResult Create(string avisoJSON)
        {
            AvisoModel avisomodel = JsonConvert.DeserializeObject<AvisoModel>(avisoJSON);
            avisomodel.DataAlteracao = DateTime.Now;
            avisomodel.DataCriacao = DateTime.Now;
            foreach (int id in avisomodel.ArquivosId)
            {
                ArquivoModel arq = db.ArquivoModels.Find(id);
                if (arq != null)
                {
                    avisomodel.Arquivos.Add(arq);
                }
            }
            foreach (int id in avisomodel.TurmasId)
            {
                TurmaModel turma = db.TurmaModels.Find(id);
                if (turma != null)
                {
                    avisomodel.Turmas.Add(turma);
                }
            }
            if (ModelState.IsValid)
            {
                db.AvisoModels.Add(avisomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avisomodel);
        }

        // GET: /Aviso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoModel avisomodel = db.AvisoModels.Find(id);
            if (avisomodel == null)
            {
                return HttpNotFound();
            }
            return View(avisomodel);
        }

        // POST: /Aviso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Aviso,DataExclusao,DataCriacao,DataAlteracao")] AvisoModel avisomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avisomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avisomodel);
        }

        // GET: /Aviso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisoModel avisomodel = db.AvisoModels.Find(id);
            if (avisomodel == null)
            {
                return HttpNotFound();
            }
            return View(avisomodel);
        }

        // POST: /Aviso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvisoModel avisomodel = db.AvisoModels.Find(id);
            db.AvisoModels.Remove(avisomodel);
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
