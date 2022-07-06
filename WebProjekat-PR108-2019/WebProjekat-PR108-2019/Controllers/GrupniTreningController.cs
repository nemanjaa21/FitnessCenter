using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{
    public class GrupniTreningController : ApiController
    {
        GrupniTreningOperacije grup = new GrupniTreningOperacije();
        // GET: api/GrupniTrening
        
        public List<GrupniTrening> Get(String id)
        {
            List<GrupniTrening> grupni = new List<GrupniTrening>();
            grupni = grup.SviGrupniTreninzi();
            List<GrupniTrening> temp = new List<GrupniTrening>();

           


            foreach (var item in grupni)
            {
                if (item.Centar.Naziv == id)
                {
                    DateTime t;
                    if (!DateTime.TryParse(item.DatumIVreme, out t))
                        continue;
                    if (t > DateTime.Now)
                        temp.Add(item);
                }
            }

            return temp;
        }

        [HttpGet, Route("api/Trening/{id}")]
        public GrupniTrening GetTrening(String id) // naziv treninga
        {

            return grup.CitajTrening(id);
        }

        // POST: api/GrupniTrening
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GrupniTrening/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/GrupniTrening/5
        public void Delete(int id)
        {
        }
    }
}
