using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat_PR108_2019.Models
{
    public class FitnesCentarOperacije
    {
        public FitnesCentarOperacije()
        {

        }
        public void UpisiFitnes(FitnesCentar fit)
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/fitnesCentri.json");
            var json = File.ReadAllText(putanja);
            var fitCentar = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
            fitCentar.Add(fit);
            File.Delete(putanja);
            File.WriteAllText(putanja, JsonConvert.SerializeObject(fitCentar));

        }

        public FitnesCentar CitajFitnes(String korIme)
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/fitnesCentri.json");
            var json = File.ReadAllText(putanja);
            var fitCentar = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
            foreach (var item in fitCentar)
            {
                if (item.Naziv == korIme)
                    return item;

            }
            return null;
        }

        public List<FitnesCentar> SviFitnesCentri()
        {
            String putanja = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/fitnesCentri.json");
            var json = File.ReadAllText(putanja);
            var fitCentar = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
            return fitCentar;
        }
        

    }
}