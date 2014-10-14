using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class CursoModel : BaseEntity
    {
        public string Descricao { get; set; }
        public int Ano { get; set; }

        public int PeriodoId { get; set; }
        [ForeignKey("PeriodoId")]
        public virtual PeriodoModel Periodo { get; set; }

        public int UnidadeId { get; set; }
        [ForeignKey("UnidadeId")]
        public virtual UnidadeModel Unidade { get; set; }

        public int PrimeiraSerie { get; set; }
        public int UltimaSerie { get; set; }

        public virtual List<TurmaModel> Turmas { get; set; }

        public string PeriodoDescricao
        {
            get
            {
                if (Periodo != null)
                {
                    return Periodo.Descricao;
                }
                return "null";
            }
        }

        public string UnidadeDescricao
        {
            get
            {
                if (Unidade != null)
                {
                    return Unidade.Descricao;
                }
                return "null";
            }
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}