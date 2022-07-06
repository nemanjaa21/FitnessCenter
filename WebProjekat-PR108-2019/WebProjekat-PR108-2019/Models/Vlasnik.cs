using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class Vlasnik : Korisnik
    {
        public List<FitnesCentar> fitnesCentri { get; set; }



        public Vlasnik(String korisnickoIme, String lozinka, String ime, String prezime,Pol pol, String email, String datumRodjenja, Uloga uloga, List<FitnesCentar> fitnesCentri) : base(korisnickoIme, lozinka, ime, prezime,pol, email, datumRodjenja, uloga)
        {
            this.fitnesCentri = new List<FitnesCentar>();
        }


    }
}