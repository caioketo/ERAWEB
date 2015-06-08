using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class BoletimModel : BaseEntity
    {
        public int AlunoCId { get; set; }
        public virtual AlunoModel Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public virtual DisciplinaModel Disciplina { get; set; }
        public Nullable<int> NotaTrim1Id { get; set; }
        public virtual NotasBoletim NotaTrim1 { get; set; }
        public Nullable<int> NotaTrim2Id { get; set; }
        public virtual NotasBoletim NotaTrim2 { get; set; }
        public Nullable<int> NotaTrim3Id { get; set; }
        public virtual NotasBoletim NotaTrim3 { get; set; }


        #region Helpers

        public virtual string DisciplinaDesc
        {
            get
            {
                if (Disciplina == null)
                {
                    return "";
                }
                return Disciplina.Descricao;
            }
        }

        public virtual string NotaTrim1Nota
        {
            get
            {
                if (NotaTrim1 == null)
                {
                    return "0";
                }
                return NotaTrim1.Nota.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim1Rec
        {
            get
            {
                if (NotaTrim1 == null || NotaTrim1.Rec < 0)
                {
                    return "";
                }
                return NotaTrim1.Rec.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual double DblNotaTrim1Media
        {
            get
            {
                if (NotaTrim1 == null)
                {
                    return 0;
                }
                return NotaTrim1.Media;
            }
        }

        public virtual string NotaTrim1Media
        {
            get
            {
                return DblNotaTrim1Media.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim1Faltas
        {
            get
            {
                if (NotaTrim1 == null || NotaTrim1.Faltas <= 0)
                {
                    return "";
                }
                return NotaTrim1.Faltas.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim2Nota
        {
            get
            {
                if (NotaTrim2 == null)
                {
                    return "";
                }
                return NotaTrim2.Nota.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim2Rec
        {
            get
            {
                if (NotaTrim2 == null || NotaTrim2.Rec < 0)
                {
                    return "";
                }
                return NotaTrim2.Rec.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual double DblNotaTrim2Media
        {
            get
            {
                if (NotaTrim2 == null)
                {
                    return 0;
                }
                return NotaTrim2.Media;
            }
        }

        public virtual string NotaTrim2Media
        {
            get
            {
                if (NotaTrim2 == null)
                {
                    return "";
                }
                return DblNotaTrim2Media.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim2Faltas
        {
            get
            {
                if (NotaTrim2 == null || NotaTrim2.Faltas <= 0)
                {
                    return "";
                }
                return NotaTrim2.Faltas.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim3Nota
        {
            get
            {
                if (NotaTrim3 == null)
                {
                    return "";
                }
                return NotaTrim3.Nota.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim3Rec
        {
            get
            {
                if (NotaTrim3 == null || NotaTrim3.Rec < 0)
                {
                    return "";
                }
                return NotaTrim3.Rec.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual double DblNotaTrim3Media
        {
            get
            {
                if (NotaTrim3 == null)
                {
                    return 0;
                }
                return NotaTrim3.Media;
            }
        }

        public virtual string NotaTrim3Media
        {
            get
            {
                if (NotaTrim3 == null)
                {
                    return "";
                }
                return DblNotaTrim3Media.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual string NotaTrim3Faltas
        {
            get
            {
                if (NotaTrim3 == null || NotaTrim3.Faltas <= 0)
                {
                    return "";
                }
                return NotaTrim3.Faltas.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual int IntTotalFaltas
        {
            get
            {
                int faltas = 0;
                if (NotaTrim1 != null)
                {
                    faltas += NotaTrim1.Faltas;
                }
                if (NotaTrim2 != null)
                {
                    faltas += NotaTrim2.Faltas;
                }
                if (NotaTrim3 != null)
                {
                    faltas += NotaTrim3.Faltas;
                }
                return faltas;
            }
        }

        public virtual string TotalFaltas
        {
            get
            {
                return IntTotalFaltas.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual int IntAulasDadas
        {
            get
            {
                int aulas = 0;
                if (NotaTrim1 != null)
                {
                    aulas += NotaTrim1.AulasDadas;
                }
                if (NotaTrim2 != null)
                {
                    aulas += NotaTrim2.AulasDadas;
                }
                if (NotaTrim3 != null)
                {
                    aulas += NotaTrim3.AulasDadas;
                }
                return aulas;
            }
        }

        public virtual string AulasDadas
        {
            get
            {
                return IntAulasDadas.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual int IntFreq
        {
            get
            {
                if (IntAulasDadas <= 0)
                {
                    return 0;
                }
                return (int)(((IntAulasDadas - IntTotalFaltas) * 100) / IntAulasDadas);
            }
        }

        public virtual string Freq
        {
            get
            {
                return IntFreq.ToString("F0", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual double DblTotalPontos
        {
            get
            {
                return (DblNotaTrim1Media + DblNotaTrim2Media + DblNotaTrim3Media);
            }
        }

        public virtual string TotalPontos
        {
            get
            {
                return DblTotalPontos.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        public virtual double DblMediaGeral
        {
            get
            {
                int i = 0;
                if (NotaTrim1 != null)
                {
                    i++;
                }
                if (NotaTrim2 != null)
                {
                    i++;
                }
                if (NotaTrim3 != null)
                {
                    i++;
                }
                return (DblTotalPontos / i);
            }
        }

        public virtual string MediaGeral
        {
            get
            {
                return DblMediaGeral.ToString("F1", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
        }

        #endregion
    }
}