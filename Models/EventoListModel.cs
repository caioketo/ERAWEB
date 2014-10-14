using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class EventoListModel
    {
        public List<EventoModel> Eventos { get; set; }
        public string TurmaDescricao { get; set; }
    }
}