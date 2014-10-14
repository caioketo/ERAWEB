using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class LicaoJSON
    {
        public string DataLicao { get; set; }
        public string Conteudo { get; set; }
        public string Disciplina { get; set; }

        public LicaoJSON() { }

        public LicaoJSON(LicaoModel model)
        {
            this.DataLicao = model.DataLicaoFormatada;
            this.Disciplina = model.Disciplina.Descricao;
            this.Conteudo = model.Conteudo;
        }

        public static List<LicaoJSON> LicoesJSON(List<LicaoModel> provas)
        {
            List<LicaoJSON> retorno = new List<LicaoJSON>();
            foreach (LicaoModel model in provas) 
            {
                LicaoJSON json = new LicaoJSON(model);
                retorno.Add(json);
            }
            return retorno;
        }
    }
}