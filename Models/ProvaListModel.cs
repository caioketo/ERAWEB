using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class ProvaListModel
    {
        public List<ProvaModel> Provas { get; set; }
        public string TurmaDescricao { get; set; }
        public int TurmaId { get; set; }
    }
}