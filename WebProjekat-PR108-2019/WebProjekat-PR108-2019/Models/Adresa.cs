using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class Adresa
    {
        //ulica i broj, mesto/grad, poštanski broj
        public String UlicaIBroj { get; set; }
        public String MestoiGrad { get; set; }
        public String PostanskiBroj { get; set; }

        public override string ToString()
        {
            return UlicaIBroj + " " + MestoiGrad + " " + PostanskiBroj;
        }
    }
}