using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class FitnesCentar
    {
        public String Naziv { get; set; }
        public Adresa Adresa { get; set; }
        public String GodinaOtvaranja { get; set; }
        public String Vlasnik { get; set; }
        public int CenaMesecneClanarine { get; set; }
        public int CenaGodisnjeClanarine { get; set; }
        public int CenaTreninga { get; set; }
        public int CenaGrupnogTreninga { get; set; }
        public int CenaTreningaSaTrenerom { get; set; }
    }
}