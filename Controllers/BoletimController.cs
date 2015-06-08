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
using ERAWeb.Models.JSON;

namespace ERAWeb.Controllers
{
    public class BoletimController : Controller
    {
        private ERAContext db = new ERAContext();


        [HttpPost]
        public string CreateAlunoJSON(string alunoJSON)
        {
            alunoJSON = Encoding.UTF8.GetString(Convert.FromBase64String(alunoJSON));
            AlunoModel alunoModel = new AlunoModel();
            var serializer = new JavaScriptSerializer();
            alunoModel = JsonConvert.DeserializeObject<AlunoModel>(alunoJSON);
            alunoModel.DataAlteracao = DateTime.Now;
            alunoModel.DataCriacao = DateTime.Now;

            if (db.AlunoModels.Where(a => a.CId == alunoModel.CId).ToList().Count <= 0)
            {
                db.AlunoModels.Add(alunoModel);
                db.SaveChanges();
            }

            return serializer.Serialize(alunoModel);
        }

        [HttpPost]
        public string CreateJSON(string boletimJSON)
        {
            boletimJSON = Encoding.UTF8.GetString(Convert.FromBase64String(boletimJSON));
            BoletimModel boletimModel = new BoletimModel();
            var serializer = new JavaScriptSerializer();
            boletimModel = JsonConvert.DeserializeObject<BoletimModel>(boletimJSON);
            boletimModel.DataAlteracao = DateTime.Now;
            boletimModel.DataCriacao = DateTime.Now;
            if (boletimModel.NotaTrim1 != null)
            {
                boletimModel.NotaTrim1.DataAlteracao = DateTime.Now;
                boletimModel.NotaTrim1.DataCriacao = DateTime.Now;
            }
            if (boletimModel.NotaTrim2 != null)
            {
                boletimModel.NotaTrim2.DataAlteracao = DateTime.Now;
                boletimModel.NotaTrim2.DataCriacao = DateTime.Now;
            }
            if (boletimModel.NotaTrim3 != null)
            {
                boletimModel.NotaTrim3.DataAlteracao = DateTime.Now;
                boletimModel.NotaTrim3.DataCriacao = DateTime.Now;
            }
            boletimModel.Aluno = db.AlunoModels.Where(a => a.CId == boletimModel.AlunoCId).FirstOrDefault();

            db.BoletimModels.Add(boletimModel);
            db.SaveChanges();
            return serializer.Serialize(boletimModel);
        }

        public ActionResult Alunos()
        {
            return View(db.AlunoModels.OrderBy(a => a.Ano).ThenBy(a => a.Turma).ThenBy(a => a.Numero).ToList());
        }

        // GET: Boletim
        public ActionResult Index(int? id)
        {
            return View(db.BoletimModels.Where(b => b.AlunoCId == id).ToList());
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
