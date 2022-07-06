using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class GrupniTrening
    {
        public GrupniTrening()
        {

        }

        public String Naziv { get; set; }
        public TipTreninga Tip { get; set; }
        public int TrajanjeTreninga { get; set; }
        public String DatumIVreme { get; set; }
        public int MaxBrojPosetilaca { get; set; }
        public int UkupanBrojPrijavljeihPosetilaca { get; set; }
        public FitnesCentar Centar { get; set; }
        public List<String> posetioci { get; set; } = new List<String>();
        public int Obrisan { get; set; }

    }
}