using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class EventoModel : BaseEntity
    {
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public virtual string DataEventoFormatado
        {
            get
            {
                return DataEvento.ToString("dd/MM/yyyy");
            }
        }

        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        
        public IList<TurmaModel> Turmas { get; set; }

        [NotMapped]
        public int[] TurmasId { get; set; }
        public string Conteudo { get; set; }

        public EventoModel()
        {
            Turmas = new List<TurmaModel>();
        }
    }
}