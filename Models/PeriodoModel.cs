using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class PeriodoModel : BaseEntity
    {
        public string Descricao { get; set; }

        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }

        public override string ToString()
        {
            return Descricao;
        }

        public string Horario
        {
            get
            {
                return HoraInicio + " às " + HoraFim;
            }
        }
    }
}