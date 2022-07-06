using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class TrenerOperacije
    {
        public TrenerOperacije()
        {

        }
        public Trener CitajTrenera(string korisnickoIme)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/trener.json");
            string json = File.ReadAllText(putanja);
            List<Trener> treneri = JsonConvert.DeserializeObject<List<Trener>>(json);
            foreach (var item in treneri)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return item;
            }
            return null;
        }
        public List<Trener> GetTrenerList()
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/trener.json");
            string json = File.ReadAllText(putanja);
            List<Trener> treneri = JsonConvert.DeserializeObject<List<Trener>>(json);
            return treneri;
        }

        public void Izmeni(Trener trener)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/trener.json");
            string json = File.ReadAllText(putanja);
            List<Trener> treneriTemp = JsonConvert.DeserializeObject<List<Trener>>(json);
            foreach (var item in treneriTemp)
            {
                if (item.KorisnickoIme == trener.KorisnickoIme)
                {
                    item.Ime = trener.Ime;
                    item.Prezime = trener.Prezime;
                    item.Lozinka = trener.Lozinka;
                    item.Email = trener.Email;
                    item.DatumRodjenja = trener.DatumRodjenja;
                    item.pol = trener.pol;
                    item.Uloga = trener.Uloga;
                    break;
                }
            }

            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(treneriTemp));
        }
    }
}