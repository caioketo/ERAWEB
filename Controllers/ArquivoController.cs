using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERAWeb.Models;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace ERAWeb.Controllers
{
    public class ArquivoController : Controller
    {
        public ERAContext GetDB()
        {
            return new ERAContext();
        }
        // GET: /Arquivo/
        public ActionResult Index()
        {
            using (var db = GetDB())
            {
                return View(db.ArquivoModels.ToList());
            }
        }

        // GET: /Arquivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = GetDB())
            {
                ArquivoModel arquivomodel = db.ArquivoModels.Find(id);
                if (arquivomodel == null)
                {
                    return HttpNotFound();
                }
                return View(arquivomodel);
            }
        }

        // GET: /Arquivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Arquivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] files, ArquivoModel arquivomodel)
        //public ActionResult Create([Bind(Include="Id,Arquivo,DataExclusao,DataCriacao,DataAlteracao")] ArquivoModel arquivomodel)
        {
            foreach (HttpPostedFileBase file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Arquivos"), fileName);
                    file.SaveAs(path);
                    if (fileName.ToUpper().Contains(".JPG"))
                    {
                        Image image = Image.FromFile(fileName);
                        Image thumb = image.GetThumbnailImage(240, 240, () => false, IntPtr.Zero);
                        thumb.Save("thumb_" + fileName);
                    }
                    arquivomodel.Arquivo = fileName;
                }

                arquivomodel.DataAlteracao = DateTime.Now;
                arquivomodel.DataCriacao = DateTime.Now;
                using (var db = GetDB())
                {
                    if (ModelState.IsValid)
                    {
                        db.ArquivoModels.Add(arquivomodel);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // POST: /Arquivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult CreateJSON(HttpPostedFileBase file, ArquivoModel arquivomodel)
        {
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/Arquivos"), fileName);
                file.SaveAs(path);
                arquivomodel.Arquivo = fileName;
            }

            arquivomodel.DataAlteracao = DateTime.Now;
            arquivomodel.DataCriacao = DateTime.Now;
            using (var db = GetDB())
            {
                if (ModelState.IsValid)
                {
                    arquivomodel = db.ArquivoModels.Add(arquivomodel);
                    db.SaveChanges();
                    return Json(new { success = true, message = arquivomodel });
                }

                return Json(new { success = false, message = "null" });
            }
        }
        // GET: /Arquivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = GetDB())
            {
                ArquivoModel arquivomodel = db.ArquivoModels.Find(id);
                if (arquivomodel == null)
                {
                    return HttpNotFound();
                }
                return View(arquivomodel);
            }
        }

        // POST: /Arquivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Arquivo,DataExclusao,DataCriacao,DataAlteracao")] ArquivoModel arquivomodel)
        {
            using (var db = GetDB())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(arquivomodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(arquivomodel);
            }
        }

        // GET: /Arquivo/Delete/5
        public ActionResult Delete(int? id)
        {
            using (var db = GetDB())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ArquivoModel arquivomodel = db.ArquivoModels.Find(id);
                if (arquivomodel == null)
                {
                    return HttpNotFound();
                }
                return View(arquivomodel);
            }
        }

        // POST: /Arquivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = GetDB())
            {
                ArquivoModel arquivomodel = db.ArquivoModels.Find(id);
                db.ArquivoModels.Remove(arquivomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
