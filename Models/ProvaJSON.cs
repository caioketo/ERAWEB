using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class ProvaJSON
    {
        public string DataProva { get; set; }
        public string Disciplina { get; set; }
        public string Descricao { get; set; }

        public ProvaJSON() { }

        public ProvaJSON(ProvaModel model)
        {
            this.DataProva = model.DataProvaFormatada;
            this.Disciplina = model.Disciplina.Descricao;
            this.Descricao = model.Descricao;
        }

        public static List<ProvaJSON> ProvasJSON(List<ProvaModel> provas)
        {
            List<ProvaJSON> retorno = new List<ProvaJSON>();
            foreach (ProvaModel model in provas) 
            {
                ProvaJSON json = new ProvaJSON(model);
                retorno.Add(json);
            }
            return retorno;
        }
    }
}