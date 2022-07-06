using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{

    public class RegistrationController : ApiController
    {
        PosetilacOperacije posetilacOp = new PosetilacOperacije();
        TrenerOperacije trenerOp = new TrenerOperacije();
        VlasnikOperacije vlasnikOp = new VlasnikOperacije();

        // GET: api/Registration
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registration
        [HttpPost]
        [Route("api/Registration")]
        public IHttpActionResult Post(Posetilac posetilac)
        {
            if (posetilac.Ime == null || posetilac.Ime.Length == 0)
                return BadRequest();
            if (posetilac.Prezime == null || posetilac.Prezime.Length == 0 )
                return BadRequest();
            if (posetilac.Email == null  || posetilac.Email.Length == 0 || !EmailFormat(posetilac.Email))
                return BadRequest();
            if (posetilac.DatumRodjenja == null || posetilac.DatumRodjenja.Length == 0)
                return BadRequest();
            if (!posetilac.pol.Equals(Pol.M) && (!posetilac.pol.Equals(Pol.Ž)))
               return BadRequest();
            if (posetilac.KorisnickoIme == null || posetilac.KorisnickoIme.Length == 0)
                return BadRequest();
            if (posetilac.Lozinka == null || posetilac.Lozinka.Length == 0)
                return BadRequest();


            if (posetilacOp.CitajPosetioca(posetilac.KorisnickoIme) is null && trenerOp.CitajTrenera(posetilac.KorisnickoIme) is null && vlasnikOp.CitajVlasnika(posetilac.KorisnickoIme) is null )
            {
                posetilac.Uloga = Uloga.Posetilac;
                posetilacOp.UpisiPosetioca(posetilac);
                return Ok(posetilac);
            }
            else
                return BadRequest();


        }

        public bool EmailFormat(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            
            if (Regex.IsMatch(email, pattern))
            {
                
                return true;
            }
            return false;
        }

        // PUT: api/Registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
