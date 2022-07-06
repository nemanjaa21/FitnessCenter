using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class KomentarOperacije
    {
        public KomentarOperacije()
        {

        }

        public void UpisiKomentar(Komentar komentar)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/komentar.json");
            string json = File.ReadAllText(putanja);
            List<Komentar> komentari = JsonConvert.DeserializeObject<List<Komentar>>(json);
            komentari.Add(komentar);
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(komentari));
        }

       
        public List<Komentar> GetKomentari()
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/komentar.json");
            string json = File.ReadAllText(putanja);
            List<Komentar> komentari = JsonConvert.DeserializeObject<List<Komentar>>(json);
            return komentari;
        }

       


    }
}