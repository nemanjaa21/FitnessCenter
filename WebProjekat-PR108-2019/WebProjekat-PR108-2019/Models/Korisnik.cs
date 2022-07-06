using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class Korisnik
    {
        public Korisnik()
        {
        }

        public Korisnik(String korisnickoIme,String lozinka,String ime, String prezime, Pol pol,
            String email,String datumRodjenja, Uloga uloga)
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

        public string KorisnickoIme { get ; set ; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol pol { get; set; }
        public string Email { get; set; }
        public String DatumRodjenja { get; set; }
        public Uloga Uloga { get; set; }
        
    }
}