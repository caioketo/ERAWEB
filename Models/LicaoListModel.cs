using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class LicaoListModel
    {
        public List<LicaoModel> Licoes { get; set; }
        public string TurmaDescricao { get; set; }
        public int TurmaId { get; set; }
    }
}