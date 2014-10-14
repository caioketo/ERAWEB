using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class DisciplinaModel : BaseEntity
    {
        public string Descricao { get; set; }
        public string Abreviatura { get; set; }
        public string NomeHistorico { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}