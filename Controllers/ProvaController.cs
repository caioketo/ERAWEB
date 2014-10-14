using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERAWeb.Models;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ERAWeb.Controllers
{
    public class ProvaController : Controller
    {
        private ERAContext db = new ERAContext();

        // GET: /Prova/
        public ActionResult Index()
        {
            var provas = db.Provas.Include(p => p.Disciplina).Include(p => p.Turma);
            return View(provas.ToList());
        }

        // GET: /Prova/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvaModel provamodel = db.Provas.Find(id);
            if (provamodel == null)
            {
                return HttpNotFound();
            }
            return View(provamodel);
        }

        // GET: /Prova/Create
        public ActionResult Create()
        {
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao");
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display");
            ViewBag.Trimestre = new SelectList(Trimestre.GetTrimestres(), "Numero", "Descricao");
            return View();
        }

        // POST: /Prova/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DataProva,Trimestre,TurmaId,DisciplinaId,Recuperacao,Descricao,DataExclusao,DataCriacao,DataAlteracao")] ProvaModel provamodel)
        {
            if (ModelState.IsValid)
            {
                provamodel.DataAlteracao = DateTime.Now;
                provamodel.DataCriacao = DateTime.Now;
                db.Provas.Add(provamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", provamodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", provamodel.TurmaId);
            return View(provamodel);
        }

        [HttpPost]
        public string CreateJSON(string provaJSON)
        {
            provaJSON = Encoding.UTF8.GetString(Convert.FromBase64String(provaJSON));
            ProvaModel provamodel = new ProvaModel();
            var serializer = new JavaScriptSerializer();
            provamodel = JsonConvert.DeserializeObject<ProvaModel>(provaJSON);
            provamodel.DataAlteracao = DateTime.Now;
            provamodel.DataCriacao = DateTime.Now;
            db.Provas.Add(provamodel);
            db.SaveChanges();
            return serializer.Serialize(provamodel);
        }

        // GET: /Prova/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvaModel provamodel = db.Provas.Find(id);
            if (provamodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", provamodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", provamodel.TurmaId);
            return View(provamodel);
        }

        // POST: /Prova/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DataProva,Trimestre,TurmaId,DisciplinaId,Recuperacao,Descricao,DataExclusao,DataCriacao,DataAlteracao")] ProvaModel provamodel)
        {
            if (ModelState.IsValid)
            {
                provamodel.DataAlteracao = DateTime.Now;
                db.Entry(provamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", provamodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", provamodel.TurmaId);
            return View(provamodel);
        }

        // GET: /Prova/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvaModel provamodel = db.Provas.Find(id);
            if (provamodel == null)
            {
                return HttpNotFound();
            }
            return View(provamodel);
        }

        // POST: /Prova/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProvaModel provamodel = db.Provas.Find(id);
            db.Provas.Remove(provamodel);
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
