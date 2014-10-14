using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Galerias()
        {
            return View();
        }

        public ActionResult Ambientes()
        {
            return View();
        }

        public ActionResult Equipe()
        {
            return View();
        }

        public ActionResult Escola()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }


        public ActionResult Feed()
        {
            ERAWeb.Models.ERAContext context = ERAWeb.Models.ERAContext.Context;
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[PeriodoModels] ([Descricao],[HoraInicio],[HoraFim],[DataExclusao],[DataCriacao],[DataAlteracao]) values " +
                            "('Matutino', '7:30', '12:00', NULL, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[UnidadeModels] ([Numero],[Descricao],[DataExclusao],[DataCriacao],[DataAlteracao]) values (1, 'Principal', null, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP) ");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[CursoModels] ([Descricao],[Ano],[PeriodoId],[UnidadeId] " +
                            ",[PrimeiraSerie],[UltimaSerie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Ensino Infantil', 2014, 1, 1, 1, 3, null, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[CursoModels] ([Descricao],[Ano],[PeriodoId],[UnidadeId] " +
                ",[PrimeiraSerie],[UltimaSerie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Ensino Fundamental', 2014, 1, 1, 1, 9, null, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Maternal I', 1, 0, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Maternal II', 1, 0, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Jardim', 1, 0, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Pré', 1, 0, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('', 2, 1, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('', 2, 2, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('', 2, 3, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('', 2, 4, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('', 2, 5, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('A', 2, 6, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('B', 2, 6, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('A', 2, 7, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('B', 2, 7, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('A', 2, 8, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[TurmaModels] ([Descricao],[CursoId],[Serie],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('A', 2, 9, null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Português', 'PORT', 'Português', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Matemática', 'MAT', 'Matemática', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('História', 'HIST', 'História', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Geografia', 'GEO', 'Geografia', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Ciências', 'CIE', 'Ciências', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Educação Física', 'FISI', 'Educação Física', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Artes', 'ART', 'Artes', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Espanhol', 'ESP', 'Espanhol', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Inglês', 'ING', 'Inglês', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Desenho Geométrico', 'DES', 'Desenho Geométrico', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Informática', 'INF', 'Informática', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Formação de Valores', 'FORM', 'Formação de Valores', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            context.Database.ExecuteSqlCommand("insert into [escolare_geral].[dbo].[DisciplinaModels] ([Descricao],[Abreviatura],[NomeHistorico],[DataExclusao],[DataCriacao],[DataAlteracao]) values ('Educação Musical', 'MUS', 'Educação Musical', null, CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)");
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EducInfantil()
        {
            return View();
        }

        public ActionResult EducFundamental()
        {
            return View();
        }

        public ActionResult Textos()
        {
            return View();
        }
    }
}