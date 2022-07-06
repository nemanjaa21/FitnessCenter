using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{
    public class LoginController : ApiController
    {
        PosetilacOperacije posetilacOp = new PosetilacOperacije();
        TrenerOperacije trenerOp = new TrenerOperacije();
        VlasnikOperacije vlasnikOp = new VlasnikOperacije();
        // GET: api/Login
        [HttpGet]
        public Korisnik Get(String id)
        {
            foreach (var posetilac in posetilacOp.GetPosetioci())
            {
                if (posetilac.KorisnickoIme.Equals(id))
                    return posetilac;
            }

            foreach (var trener in trenerOp.GetTrenerList())
            {
                if(trener.KorisnickoIme.Equals(id))
                    return trener;

            }

            foreach (var vlasnik in vlasnikOp.GetVlasnikList())
            {
                if (vlasnik.KorisnickoIme.Equals(id))
                    return vlasnik;

            }


            return null;
        }

        

        // POST: api/Login
        [HttpPost]
        public IHttpActionResult Post([FromBody]Korisnik korisnik)
        {

            if ((korisnik.KorisnickoIme == null || korisnik.KorisnickoIme.Length == 0) || (korisnik.Lozinka == null || korisnik.Lozinka.Length == 0))
                 return BadRequest();

            foreach (var posetilac in posetilacOp.GetPosetioci())
            {
                if (posetilac.KorisnickoIme == korisnik.KorisnickoIme && posetilac.Lozinka == korisnik.Lozinka)
                {
                    return Ok(posetilac);
                }
               
            }

            foreach (var trener in trenerOp.GetTrenerList())
            {
                if (trener.KorisnickoIme == korisnik.KorisnickoIme && trener.Lozinka == korisnik.Lozinka)
                {
                    return Ok(trener);
                }
               
            }

            foreach (var vlasnik in vlasnikOp.GetVlasnikList())
            {
                if (vlasnik.KorisnickoIme == korisnik.KorisnickoIme && vlasnik.Lozinka == korisnik.Lozinka)
                {
                    return Ok(vlasnik);
                }



            }

            return BadRequest();
            
        }

        // PUT: api/Login/5
        [HttpPut]
        //kada je ulogovan da moze da izmeni svoj nalog
        public IHttpActionResult Put(String id,[FromBody]Korisnik value)
        {
            if(value == null)
                return BadRequest();

            if (value.Ime == null || value.Ime.Length == 0)
                return BadRequest();

            if (value.Prezime == null || value.Prezime.Length == 0)
                return BadRequest();

            if (value.KorisnickoIme == null || value.KorisnickoIme.Length == 0)
                return BadRequest();

            if (value.Lozinka == null || value.Lozinka.Length == 0)
                return BadRequest();

            if (value.pol != Pol.M && value.pol != Pol.Ž)
                return BadRequest();

            if (value.Email == null || value.Email.Length == 0)
                return BadRequest();

            if (value.DatumRodjenja == null || value.DatumRodjenja.Length == 0)
                return BadRequest();


            foreach (var posetilac in posetilacOp.GetPosetioci())
            {
                if (posetilac.KorisnickoIme.Equals(id))
                {


                    posetilac.Ime = value.Ime;

                    posetilac.Prezime = value.Prezime;

                    posetilac.KorisnickoIme = value.KorisnickoIme;

                    posetilac.Lozinka = value.Lozinka;

                    posetilac.Email = value.Email;

                    posetilac.DatumRodjenja = value.DatumRodjenja;

                    posetilac.pol = value.pol;

                    posetilacOp.Izmeni(posetilac);

                    return Ok(posetilac);

                }
            }

            foreach (var trener in trenerOp.GetTrenerList())
            {
                if (trener.KorisnickoIme.Equals(id))
                {


                   trener.Ime = value.Ime;

                   trener.Prezime = value.Prezime;

                    trener.Lozinka = value.Lozinka;

                   trener.Email = value.Email;

                    trener.DatumRodjenja = value.DatumRodjenja;
                   trener.pol = value.pol;

                   trenerOp.Izmeni(trener);

                  return Ok(trener);

               }
            }

            foreach (var vlasnik in vlasnikOp.GetVlasnikList())
            {
                if (vlasnik.KorisnickoIme.Equals(id))
                {


                   vlasnik.Ime = value.Ime;

                   vlasnik.Prezime = value.Prezime;

                   vlasnik.Lozinka = value.Lozinka;

                   vlasnik.Email = value.Email;

                   vlasnik.DatumRodjenja = value.DatumRodjenja;

                   vlasnik.pol = value.pol;

                   vlasnikOp.Izmeni(vlasnik);
                    

                   return Ok(vlasnik);

                }
            }



            return BadRequest();
        }

        
    }
}
