using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERAWeb.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace ERAWeb.Controllers
{
    public class LicaoController : Controller
    {
        private ERAContext db = new ERAContext();

        // GET: /Licao/
        public ActionResult Index()
        {
            var licoes = db.Licoes.Include(l => l.Disciplina).Include(l => l.Turma);
            return View(licoes.ToList());
        }

        // GET: /Licao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicaoModel licaomodel = db.Licoes.Find(id);
            if (licaomodel == null)
            {
                return HttpNotFound();
            }
            return View(licaomodel);
        }

        // GET: /Licao/Create
        public ActionResult Create()
        {
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao");
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display");
            return View();
        }

        // POST: /Licao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DataLicao,Conteudo,DisciplinaId,TurmaId,DataExclusao,DataCriacao,DataAlteracao")] LicaoModel licaomodel)
        {
            if (ModelState.IsValid)
            {
                licaomodel.DataAlteracao = DateTime.Now;
                licaomodel.DataCriacao = DateTime.Now;
                db.Licoes.Add(licaomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", licaomodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", licaomodel.TurmaId);
            return View(licaomodel);
        }

        [HttpPost]
        public string CreateJSON(string licaoJSON)
        {
            licaoJSON = Encoding.UTF8.GetString(Convert.FromBase64String(licaoJSON));
            LicaoModel licaomodel = new LicaoModel();
            var serializer = new JavaScriptSerializer();
            licaomodel = JsonConvert.DeserializeObject<LicaoModel>(licaoJSON);
            licaomodel.DataAlteracao = DateTime.Now;
            licaomodel.DataCriacao = DateTime.Now;
            DisciplinaModel dis = ERAContext.Context.DisciplinaModels.Find(licaomodel.DisciplinaId);


            db.Licoes.Add(licaomodel);
            db.SaveChanges();
            return serializer.Serialize(licaomodel);
        }

        // GET: /Licao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicaoModel licaomodel = db.Licoes.Find(id);
            if (licaomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", licaomodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", licaomodel.TurmaId);
            return View(licaomodel);
        }

        // POST: /Licao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DataLicao,Conteudo,DisciplinaId,TurmaId,DataExclusao,DataCriacao,DataAlteracao")] LicaoModel licaomodel)
        {
            if (ModelState.IsValid)
            {
                licaomodel.DataAlteracao = DateTime.Now;
                db.Entry(licaomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisciplinaId = new SelectList(db.DisciplinaModels, "Id", "Descricao", licaomodel.DisciplinaId);
            ViewBag.TurmaId = new SelectList(db.TurmaModels, "Id", "Display", licaomodel.TurmaId);
            return View(licaomodel);
        }

        // GET: /Licao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicaoModel licaomodel = db.Licoes.Find(id);
            if (licaomodel == null)
            {
                return HttpNotFound();
            }
            return View(licaomodel);
        }

        // POST: /Licao/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicaoModel licaomodel = db.Licoes.Find(id);
            db.Licoes.Remove(licaomodel);
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
