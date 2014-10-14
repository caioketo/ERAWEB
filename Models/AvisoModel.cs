using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class AvisoModel : BaseEntity
    {
        public string Aviso { get; set; }
        [NotMapped]
        public int[] ArquivosId { get; set; }
        public virtual List<ArquivoModel> Arquivos { get; set; }
        [NotMapped]
        public int[] TurmasId { get; set; }
        public virtual List<TurmaModel> Turmas { get; set; }


        public AvisoModel()
        {
            Arquivos = new List<ArquivoModel>();
            Turmas = new List<TurmaModel>();
        }
    }
}