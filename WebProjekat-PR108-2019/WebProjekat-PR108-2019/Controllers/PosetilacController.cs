using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{
    public class PosetilacController : ApiController
    {
        GrupniTreningOperacije grupTrOp = new GrupniTreningOperacije();
        PosetilacOperacije posetilacOp = new PosetilacOperacije();

        // GET: api/Posetilac

        public List<GrupniTrening> Get(String id) // dobavi grupne treninge na kojima je posetilac ucestvovao
        {
            List<GrupniTrening> grupni = new List<GrupniTrening>();
            grupni = grupTrOp.SviGrupniTreninzi();
            List<GrupniTrening> temp = new List<GrupniTrening>();
            

            foreach (var item in grupni)
            {
                if (item.posetioci.Contains(id))
                {
                    DateTime t;
                    if (!DateTime.TryParse(item.DatumIVreme, out t))
                        continue;
                    if (t < DateTime.Now)
                        temp.Add(item);
                }
            }

            return temp;
        }

        //// GET: api/Posetilac/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Posetilac
        public void Post(String id)
        {
          
        
        }

        //// PUT: api/Posetilac/5
        public IHttpActionResult Put(String id,[FromBody]GrupniTrening value)
        {
            if (posetilacOp.CitajPosetioca(id) == null  || !(grupTrOp.UpisiUListuPosetioca(id,value)))
                return BadRequest();

            posetilacOp.UpisiUListuGrupnihTreninga(id,value.Naziv);
            return Ok();
        }

        // DELETE: api/Posetilac/5
        public void Delete(int id)
        {
        }
    }
}
