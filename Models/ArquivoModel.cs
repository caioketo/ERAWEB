using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class ArquivoModel : BaseEntity
    {
        public string Arquivo { get; set; }
        public string Descricao { get; set; }
        public IList<AvisoModel> Avisos { get; set; }
    }
}