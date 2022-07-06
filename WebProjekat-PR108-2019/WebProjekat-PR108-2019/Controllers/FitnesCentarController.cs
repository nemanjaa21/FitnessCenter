using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat_PR108_2019.Models;

namespace WebProjekat_PR108_2019.Controllers
{
    
    public class FitnesCentarController : ApiController
    {
        FitnesCentarOperacije fitOp = new FitnesCentarOperacije();
       
        // GET: api/FitnesCentar
        [HttpGet,Route("api/FitnesCentar")]
        public List<FitnesCentar> Get()
        {
            List<FitnesCentar> temp = new List<FitnesCentar>();
            temp = fitOp.SviFitnesCentri();
            FitnesCentar fitTemp = new FitnesCentar();
            for (int j = 0; j <= temp.Count() - 2; j++)
            {
                for (int i = 0; i <= temp.Count() - 2; i++)
                {
                    if(String.Compare(temp[i].Naziv , temp[i + 1].Naziv) > 0)
                    {
                        fitTemp = temp[i + 1];
                        temp[i + 1] = temp[i];
                        temp[i] = fitTemp;
                    }
                }
            }

            return temp;
        }

        //GET: api/FitnesCentar/naziv
       [HttpGet,Route("api/FitnesCentar/{naziv}")]
        public FitnesCentar Get(string naziv)
        {


            return fitOp.CitajFitnes(naziv);

        }

        
    }
}
 