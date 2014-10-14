using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class ProvaModel : BaseEntity
    {
        [Display(Name = "Data da Prova")]
        public DateTime DataProva { get; set; }
        public virtual string DataProvaFormatada
        {
            get
            {
                return DataProva.ToString("dd/MM/yyyy");
            }
        }
        public int Trimestre { get; set; }
        public virtual string TrimestreFormatado
        {
            get
            {
                return Trimestre.ToString() + "º Trimestre";
            }
        }
        public int TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        public virtual TurmaModel Turma { get; set; }
        public int DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public virtual DisciplinaModel Disciplina { get; set; }
        public bool Recuperacao { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}