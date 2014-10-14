using ERAWeb.Models;
using ERAWeb.Models.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ERAWeb.Controllers
{
    public class CPAController : Controller
    {
        private ERAContext context = new ERAContext();

        // GET: CPA
        public ActionResult Index()
        {
            return View();
        }

        public string TurmasIndex()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(TurmaJSON.TurmasJSON(context.TurmaModels.Where(a => !a.DataExclusao.HasValue).ToList()));
        }

        public string DisciplinasIndex()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(context.DisciplinaModels.Where(a => !a.DataExclusao.HasValue).ToList());
        }

        [HttpPost]
        public void CreateLicao(string data)
        {
            data = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            LicaoModel licaomodel = new LicaoModel();
            licaomodel = JsonConvert.DeserializeObject<LicaoModel>(data);
            licaomodel.DataAlteracao = DateTime.Now;
            licaomodel.DataCriacao = DateTime.Now;
            context.Licoes.Add(licaomodel);
            context.SaveChanges();
        }
    }
}