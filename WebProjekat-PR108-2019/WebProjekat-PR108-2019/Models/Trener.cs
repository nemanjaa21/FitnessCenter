using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class Trener : Korisnik
    {
        public List<String> GrupniTreningTrener { get; set; } = new List<String>();
        public String FitnesCentar { get; set; }

        
        public Trener(String korisnickoIme, String lozinka, String ime, String prezime, Pol pol, String email, String datumRodjenja, Uloga uloga) : base(korisnickoIme, lozinka, ime, prezime ,pol, email, datumRodjenja, uloga)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.pol = pol;
            this.Email = email;
            this.DatumRodjenja = datumRodjenja;
            this.Uloga = uloga;
            


        }
    }
}