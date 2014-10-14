using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class Trimestre
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }

        public static List<Trimestre> GetTrimestres()
        {
            List<Trimestre> r = new List<Trimestre>();
            r.Add(new Trimestre()
            {
                Numero = 1,
                Descricao = "1º Trimestre"
            });
            r.Add(new Trimestre()
            {
                Numero = 2,
                Descricao = "2º Trimestre"
            });
            r.Add(new Trimestre()
            {
                Numero = 3,
                Descricao = "3º Trimestre"
            });
            return r;
        }
    }
}