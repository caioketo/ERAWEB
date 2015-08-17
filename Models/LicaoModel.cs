using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class LicaoModel : BaseEntity
    {
        [Display(Name="Data da Lição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataLicao { get; set; }
        public virtual string DataLicaoFormatada
        {
            get
            {
                return DataLicao.ToString("dd/MM/yyyy");
            }
        }

        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }
        [Display(Name = "Disciplina")]
        public int DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public virtual DisciplinaModel Disciplina { get; set; }
        [Display(Name = "Turma")]
        public int TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        public virtual TurmaModel Turma { get; set; }

        public override string ToString()
        {
            return Conteudo;
        }
    }
}