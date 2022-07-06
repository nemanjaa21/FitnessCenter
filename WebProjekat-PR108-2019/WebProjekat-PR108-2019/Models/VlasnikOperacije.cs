using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class VlasnikOperacije
    {
        public VlasnikOperacije()
        {

        }

        public Vlasnik CitajVlasnika(string korisnickoIme)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/vlasnik.json");
            string json = File.ReadAllText(putanja);
            List<Vlasnik> vlasnici = JsonConvert.DeserializeObject<List<Vlasnik>>(json);
            foreach (var item in vlasnici)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return item;
            }
            return null;
        }

        public List<Vlasnik> GetVlasnikList()
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/vlasnik.json");
            string json = File.ReadAllText(putanja);
            List<Vlasnik> vlasnici = JsonConvert.DeserializeObject<List<Vlasnik>>(json);
            return vlasnici;
        }

        public void Izmeni(Vlasnik vlasnik)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/vlasnik.json");
            string json = File.ReadAllText(putanja);
            List<Vlasnik> vlasniciTemp = JsonConvert.DeserializeObject<List<Vlasnik>>(json);
            foreach (var item in vlasniciTemp)
            {
                if (item.KorisnickoIme == vlasnik.KorisnickoIme)
                {
                    item.Ime = vlasnik.Ime;
                    item.Prezime = vlasnik.Prezime;
                    item.Lozinka = vlasnik.Lozinka;
                    item.Email = vlasnik.Email;
                    item.DatumRodjenja = vlasnik.DatumRodjenja;
                    item.pol = vlasnik.pol;
                    item.Uloga = vlasnik.Uloga;
                    break;
                }
            }

            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(vlasniciTemp));
        }
    }
}