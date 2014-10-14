using ERAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERAWeb.Controllers
{
    public class AgendaController : Controller
    {
        private ERAContext context = new ERAContext();

        // GET: Agenda
        public ActionResult Index()
        {
            SelecionaSerieModel model = new SelecionaSerieModel();
            model.Cursos = context.CursoModels.Where(c => !c.DataExclusao.HasValue).ToList();
            model.HRef = "Teste";
            return View("_SelectTurma", model);
        }

        public ActionResult SelecioneTurma(string next)
        {
            SelecionaSerieModel model = new SelecionaSerieModel();
            model.Cursos = context.CursoModels.Where(c => !c.DataExclusao.HasValue).ToList();
            model.HRef = next;
            return View("_SelectTurma", model);
        }

        public ActionResult Selecionar(int id, string next)
        {
            return RedirectToAction(next, "Agenda", new { id = id });
        }

        public ActionResult Teste(int id)
        {
            return View();
        }

        public ActionResult Avisos(int id)
        {
            AvisoListModel avisoList = new AvisoListModel();
            avisoList.Avisos = context.AvisoModels.Where(a => !a.DataExclusao.HasValue && a.Turmas.Any(t => t.Id == id)).OrderByDescending(a => a.Id).ToList();
            TurmaModel turma = context.TurmaModels.Where(t => t.Id == id).FirstOrDefault();
            if (turma.Serie > 0)
            {
                avisoList.TurmaDescricao = turma.Serie + "º Ano " + turma.Descricao;
            }
            else
            {
                avisoList.TurmaDescricao = turma.Descricao;
            }
            return View(avisoList);
        }

        public ActionResult Provas(int id)
        {
            ProvaListModel provaList = new ProvaListModel();
            provaList.Provas = context.Provas.Where(a => !a.DataExclusao.HasValue && a.TurmaId == id).ToList();
            TurmaModel turma = context.TurmaModels.Where(t => t.Id == id).FirstOrDefault();
            if (turma.Serie > 0)
            {
                provaList.TurmaDescricao = turma.Serie + "º Ano " + turma.Descricao;
            }
            else
            {
                provaList.TurmaDescricao = turma.Descricao;
            }
            provaList.TurmaId = turma.Id;
            return View(provaList);
        }

        public string ProvasTrim(int id, int trimestre)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProvaJSON.ProvasJSON(context.Provas.Where(a => !a.DataExclusao.HasValue && a.TurmaId == id && a.Trimestre == trimestre && !a.Recuperacao).ToList()));
        }

        public string ProvasRecTrim(int id, int trimestre)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProvaJSON.ProvasJSON(context.Provas.Where(a => !a.DataExclusao.HasValue && a.TurmaId == id && a.Trimestre == trimestre && a.Recuperacao).ToList()));
        }

        public ActionResult Licoes(int id)
        {
            LicaoListModel licaoList = new LicaoListModel();
            licaoList.Licoes = context.Licoes.Where(a => !a.DataExclusao.HasValue && a.TurmaId == id).ToList();
            TurmaModel turma = context.TurmaModels.Where(t => t.Id == id).FirstOrDefault();
            if (turma.Serie > 0)
            {
                licaoList.TurmaDescricao = turma.Serie + "º Ano " + turma.Descricao;
            }
            else
            {
                licaoList.TurmaDescricao = turma.Descricao;
            }
            licaoList.TurmaId = turma.Id;
            return View(licaoList);
        }

        public string LicoesMes(int id, int mes)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(LicaoJSON.LicoesJSON(context.Licoes.Where(a => !a.DataExclusao.HasValue && a.TurmaId == id && a.DataLicao.Month == mes).ToList()));
        }
    }
}