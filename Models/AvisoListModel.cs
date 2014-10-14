using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class AvisoListModel
    {
        public List<AvisoModel> Avisos { get; set; }
        public string TurmaDescricao { get; set; }
    }
}