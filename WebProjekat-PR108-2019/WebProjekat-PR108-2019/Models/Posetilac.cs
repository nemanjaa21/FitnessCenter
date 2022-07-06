using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class Posetilac : Korisnik
    {
        public List<String> GrupniTreninzi { get; set; }
        public Posetilac(String korisnickoIme, String lozinka, String ime, String prezime,Pol pol, String email, String datumRodjenja, Uloga uloga): base(korisnickoIme,lozinka,ime,prezime,pol,email,datumRodjenja,uloga)
        {
            this.GrupniTreninzi = new List<String>();
        }
    }
}