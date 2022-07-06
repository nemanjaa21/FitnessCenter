using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class PosetilacOperacije
    {
        public PosetilacOperacije()
        {

        }

        public void UpisiPosetioca(Posetilac posetilac)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/posetilac.json");
            string json = File.ReadAllText(putanja);
            List<Posetilac> posetioci = JsonConvert.DeserializeObject<List<Posetilac>>(json);
            posetioci.Add(posetilac);
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(posetioci));
        }

        public Posetilac CitajPosetioca(string korisnickoIme)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/posetilac.json");
            string json = File.ReadAllText(putanja);
            List<Posetilac> posetioci = JsonConvert.DeserializeObject<List<Posetilac>>(json);
            foreach (var item in posetioci)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return item;
            }
            return null;
        }

        public List<Posetilac> GetPosetioci()
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/posetilac.json");
            string json = File.ReadAllText(putanja);
            List<Posetilac> posetioci = JsonConvert.DeserializeObject<List<Posetilac>>(json);
            return posetioci;
        }

        public void Izmeni(Posetilac posetilac)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/posetilac.json");
            string json = File.ReadAllText(putanja);
            List<Posetilac> posetioci = JsonConvert.DeserializeObject<List<Posetilac>>(json);



            foreach (var item in posetioci)
            {
                if (item.KorisnickoIme == posetilac.KorisnickoIme)
                {
                    item.Ime = posetilac.Ime;
                    item.Prezime = posetilac.Prezime;
                    item.DatumRodjenja = posetilac.DatumRodjenja;
                    item.Email = posetilac.Email;
                    item.Lozinka = posetilac.Lozinka;
                    item.pol = posetilac.pol;
                    item.Uloga = posetilac.Uloga;
                    
                    

                    break;
                }
            }
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(posetioci));
        }

        public void UpisiUListuGrupnihTreninga(String posetilac,String grupniNaziv)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/posetilac.json");
            string json = File.ReadAllText(putanja);
            List<Posetilac> posetioci = JsonConvert.DeserializeObject<List<Posetilac>>(json);



            foreach (var item in posetioci)
            {
                if (item.KorisnickoIme == posetilac)
                {
                    item.GrupniTreninzi.Add(grupniNaziv);


                    break;
                }
            }
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(posetioci));
        }


    }
}