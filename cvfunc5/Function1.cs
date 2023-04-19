using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;

using System.Collections.Generic;

namespace cvfunc5
{
    public static class Function1
    {

        [FunctionName("details")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "details")] HttpRequest req,
            ILogger log)
        {
            var myObj = new { etuNimi = "Antto Hautamäki", email = "antto.hautamaki@elisanet.fi", gsm = "0505607764", kaupunki = "Tampere" };
            var jsonToReturn = JsonConvert.SerializeObject(myObj);

            var answer= new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };

             answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;
        }

        struct Work
        {
            public string yrityksenNimi;
            public double kesto;
            public string tarina;
            public string kuvaus;
        };

        [FunctionName("work")]
        public static async Task<HttpResponseMessage> Run1(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "workexperience")] HttpRequest req,
           ILogger log)
        {


            List<Work> workList = new List<Work>();
            workList.Add(new Work()
            {
                yrityksenNimi = "twoday",
                kesto = 1,
                kuvaus = "Twoday:lla olin sekä Java-koodaaja että testaaja",
                tarina = "En ollut ikinä ennen toiminut varsinaisena testaajana, mutta alle puolessa vuodessa minusta tuli tarkka testaaja ja voitin pomoni luottamuksen"
            });

            workList.Add(new Work()
            {
                yrityksenNimi = "Eatech",
                kesto = 1,
                kuvaus = "Osallistuin sisäisen osaamisjärjestelmän tuotekehitykseen(FULLSTACK,,json, C#,javascript), pdf-raporttien tekoon(C#) ja Mobiilisovelluksen ohjelmointiin(React Native ) osana tuotekehitystiimiä.",
                tarina = "Eräässä vaiheessa projektitiimistäni oli puolet kerralla poissa töistä, mukaan lukien pomo, tilanne ei ollut minulle haastava"
            });

            workList.Add(new Work()
            {
                yrityksenNimi = "Logia Software",
                kesto = 4,
                kuvaus = "Toimin osana B2B-integraatiotiimiä rakentaen XSL-muunnoksia rajapintoihin ja yksinkertaisia liittymiä asiakaan ERP-järjestelmien ja Itellan varastonhallintajärjestelmän (WMS) välille. Olin mukana myös erillisissä JAVA-projekteissa ja toimin liittymätukitehtävissä. Toteutin Itella-konsernin Salesforce CRM:ään lisämoduulin Apexkoodilla. .",
                tarina = "Salesforce-projektissa yllätin asiakkaan sitkeydelläni, sain kehitettyä ominaisuuden, jonka onnistumiseen asiakas ei uskonut."
            });


            var jsonToReturn = JsonConvert.SerializeObject(workList);

            var answer= new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;
        }


        struct Lan
        {
            public int vuodet;
            public string lanquage;

        };

        [FunctionName("workdetails")]
        public static async Task<HttpResponseMessage> run2(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "workdetails")] HttpRequest req,
          ILogger log)
        {
            List<Lan> lans = new List<Lan>();

            lans.Add(new()
            {
                vuodet = 2,
                lanquage = "reactjs"

            });
            lans.Add(new()
            {
                vuodet = 4,
                lanquage = "C#"

            });
            lans.Add(new()
            {
                vuodet = 4,
                lanquage = "Java"

            });
            lans.Add(new()
            {
                vuodet = 2,
                lanquage = "C++"

            });

            var myObj = new { yritys = "twoday", story = "jjj" };
            var jsonToReturn = JsonConvert.SerializeObject(lans);

             var answer =new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;
        }

        [FunctionName("education")]
        public static async Task<HttpResponseMessage> run3(
  [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "education")] HttpRequest req,
  ILogger log)
        {
            var myObj = new { koulu = "Tampereen Teknillinen Yliopisto", tutkinto = "Diplomi-insinööri" };
            var jsonToReturn = JsonConvert.SerializeObject(myObj);

            var answer = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
            answer.Headers.Add("Access-Control-Allow-Origin", "*");
            return answer;
        }


    }
}
