using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models.JSON
{
    public class TurmaJSON
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TurmaJSON(TurmaModel model)
        {
            this.Id = model.Id;
            this.Descricao = model.ToString();
        }

        public static List<TurmaJSON> TurmasJSON(List<TurmaModel> turmas)
        {
            List<TurmaJSON> retorno = new List<TurmaJSON>();
            foreach (TurmaModel model in turmas) 
            {
                TurmaJSON json = new TurmaJSON(model);
                retorno.Add(json);
            }
            return retorno;
        }
    }
}