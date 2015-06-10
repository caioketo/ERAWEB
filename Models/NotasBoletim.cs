using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class NotasBoletim : BaseEntity
    {
        public double Nota { get; set; }
        public double Rec { get; set; }
        public double Media { get; set; }
        public int Faltas { get; set; }
        public int AulasDadas { get; set; }

        public string Recuperacao
        {
            get
            {
                if (Rec > 0)
                {
                    return Rec.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}