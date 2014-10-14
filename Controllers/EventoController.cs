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
using System.Text;
using System.Web.Script.Serialization;

namespace ERAWeb.Controllers
{
    public class EventoController : Controller
    {
        private ERAContext db = new ERAContext();

        // GET: /Evento/
        public ActionResult Index()
        {
            return View(db.EventoModels.ToList());
        }

        // GET: /Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoModel eventomodel = db.EventoModels.Find(id);
            if (eventomodel == null)
            {
                return HttpNotFound();
            }
            return View(eventomodel);
        }

        // GET: /Evento/Create
        public ActionResult Create()
        {
            ViewBag.Turmas = new SelectList(db.TurmaModels, "Id", "Display");
            return View();
        }

        // POST: /Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(string eventoJSON)//[Bind(Include="Id,Titulo,DataEvento,Inicio,Fim,Conteudo,DataExclusao,DataCriacao,DataAlteracao,TurmasId")] EventoModel eventomodel, int[] turmasId)
        {
            EventoModel eventomodel = JsonConvert.DeserializeObject<EventoModel>(eventoJSON);
            eventomodel.Inicio = new DateTime(eventomodel.DataEvento.Year, eventomodel.DataEvento.Month, eventomodel.DataEvento.Day, eventomodel.Inicio.Hour, eventomodel.Inicio.Minute, 0);
            eventomodel.Fim = new DateTime(eventomodel.DataEvento.Year, eventomodel.DataEvento.Month, eventomodel.DataEvento.Day, eventomodel.Fim.Hour, eventomodel.Fim.Minute, 0);
            eventomodel.DataAlteracao = DateTime.Now;
            eventomodel.DataCriacao = DateTime.Now;
            foreach (int id in eventomodel.TurmasId)
            {
                TurmaModel turma = db.TurmaModels.Find(id);
                if (turma != null) 
                {
                    eventomodel.Turmas.Add(turma);
                }                
            }
            if (ModelState.IsValid)
            {
                db.EventoModels.Add(eventomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventomodel);
        }


        [HttpPost]
        public string CreateJSON(string eventoJSON)
        {
            eventoJSON = Encoding.UTF8.GetString(Convert.FromBase64String(eventoJSON));
            EventoModel eventomodel = new EventoModel();
            var serializer = new JavaScriptSerializer();
            eventomodel = JsonConvert.DeserializeObject<EventoModel>(eventoJSON);
            eventomodel.DataAlteracao = DateTime.Now;
            eventomodel.DataCriacao = DateTime.Now;
            db.EventoModels.Add(eventomodel);
            db.SaveChanges();
            return serializer.Serialize(eventomodel);
        }


        // GET: /Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoModel eventomodel = db.EventoModels.Find(id);
            if (eventomodel == null)
            {
                return HttpNotFound();
            }
            return View(eventomodel);
        }

        // POST: /Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Titulo,DataEvento,Inicio,Fim,Conteudo,DataExclusao,DataCriacao,DataAlteracao")] EventoModel eventomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventomodel);
        }

        // GET: /Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventoModel eventomodel = db.EventoModels.Find(id);
            if (eventomodel == null)
            {
                return HttpNotFound();
            }
            return View(eventomodel);
        }

        // POST: /Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventoModel eventomodel = db.EventoModels.Find(id);
            db.EventoModels.Remove(eventomodel);
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
