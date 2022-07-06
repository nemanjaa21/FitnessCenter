using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{
    public class KomentarController : ApiController
    {
        KomentarOperacije komOp = new KomentarOperacije();
        GrupniTreningOperacije grupTrOp = new GrupniTreningOperacije();
        
        // GET: api/Komentar
        [HttpGet, Route("api/Komentar/{naziv}")]
        public List<Komentar> Get(String naziv)
        {

            List<Komentar> kom = new List<Komentar>();
            kom = komOp.GetKomentari();
            List<Komentar> temp = new List<Komentar>();
            foreach (var item in kom)
            {
                if (item.FitnesCentar == naziv)
                    temp.Add(item);
            }

            return temp;
        }

        public IHttpActionResult Put ([FromBody]Komentar komentar ) 
        {
            List<GrupniTrening> grupni = new List<GrupniTrening>();
            grupni = grupTrOp.SviGrupniTreninzi();
            List<GrupniTrening> temp = new List<GrupniTrening>();

            foreach (var item in grupni)
            {
                if (item.posetioci.Contains(komentar.Posetilac))
                {
                    komOp.UpisiKomentar(komentar);
                    return Ok();
                }
            }

            return Unauthorized();
        }
    }
}
