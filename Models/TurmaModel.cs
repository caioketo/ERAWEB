using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class TurmaModel : BaseEntity
    {
        [NotMapped]
        [Display(Name = "Turma")]
        public string Display
        {
            get
            {
                return this.ToString();
            }
        }

        public string Descricao { get; set; }
        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public virtual CursoModel Curso { get; set; }

        public int Serie { get; set; }

        public IList<EventoModel> Eventos { get; set; }
        public IList<AvisoModel> Avisos { get; set; }

        public virtual string CursoDescricao
        {
            get
            {
                if (Curso != null)
                {
                    return Curso.Descricao;
                }
                else
                {
                    return "";
                }
            }
        }

        public override string ToString()
        {
            if (Serie > 0)
            {
                return Serie.ToString() + "º Ano " + Descricao;
            }
            else
            {
                return Descricao;
            }            
        }
    }
}