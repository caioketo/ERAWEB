using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class AlunoModel : BaseEntity
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        //UnidadePeriodoCursoAnoTurmaNumero
        public string UPCATN { get; set; }
        [Key]
        [Column(Order=2)]
        public int CId { get; set; }
        public int Ano { get; set; }
        public string Turma { get; set; }
        public int Numero { get; set; }
    }
}