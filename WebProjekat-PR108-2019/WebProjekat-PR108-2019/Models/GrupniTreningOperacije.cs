using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class GrupniTreningOperacije
    {
        public GrupniTreningOperacije()
        {

        }
        public void UpisiFitnes(GrupniTrening gr)
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/grupniTreninzi.json");
            string json = File.ReadAllText(putanja);
            List<GrupniTrening> grupniTren = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
            grupniTren.Add(gr);
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(grupniTren));

        }

        public GrupniTrening CitajTrening(String naziv)
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/grupniTreninzi.json");
            string json = File.ReadAllText(putanja);
            List<GrupniTrening> grupniTren = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
            foreach (var item in grupniTren)
            {
                if (item.Naziv == naziv)
                    return item;

            }
            return null;
        }

        public List<GrupniTrening> SviGrupniTreninzi()
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/grupniTreninzi.json");
            string json = File.ReadAllText(putanja);
            List<GrupniTrening> grup = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
            return grup;
        }

        public List<GrupniTrening> SviGrupniTreninziZaCentar(String naziv)
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/grupniTreninzi.json");
            string json = File.ReadAllText(putanja);
            List<GrupniTrening> grup = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
            foreach (GrupniTrening item in grup)
            {
                if (item.Centar.Naziv == naziv)
                    grup.Add(item);
                
            }

            return grup;
        }

       
        public bool UpisiUListuPosetioca(String korime,GrupniTrening grupn)
        {
            string putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/grupniTreninzi.json");
            string json = File.ReadAllText(putanja);
            List<GrupniTrening> grup = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);



            foreach (GrupniTrening item in grup)
            {
                if (item.Naziv == grupn.Naziv )
                {
                    if (item.posetioci.Contains(korime) || item.posetioci.Count() >= item.MaxBrojPosetilaca )
                    {
                        return false;
                    }
                    item.posetioci.Add(korime);


                    break;
                }
            }
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(grup));
            return true;
        }

    }
}