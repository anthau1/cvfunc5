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
            var myObj = new { etuNimi = "Antto Hautam�ki", email = "antto.hautamaki@elisanet.fi", gsm = "0505607764", kaupunki = "Tampere" };
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
                kuvaus = "Twoday:lla olin sek� Java-koodaaja ett� testaaja",
                tarina = "En ollut ikin� ennen toiminut varsinaisena testaajana, mutta alle puolessa vuodessa minusta tuli tarkka testaaja ja voitin pomoni luottamuksen"
            });

            workList.Add(new Work()
            {
                yrityksenNimi = "Eatech",
                kesto = 1,
                kuvaus = "Osallistuin sis�isen osaamisj�rjestelm�n tuotekehitykseen(FULLSTACK,,json, C#,javascript), pdf-raporttien tekoon(C#) ja Mobiilisovelluksen ohjelmointiin(React Native ) osana tuotekehitystiimi�.",
                tarina = "Er��ss� vaiheessa projektitiimist�ni oli puolet kerralla poissa t�ist�, mukaan lukien pomo, tilanne ei ollut minulle haastava"
            });

            workList.Add(new Work()
            {
                yrityksenNimi = "Logia Software",
                kesto = 4,
                kuvaus = "Toimin osana B2B-integraatiotiimi� rakentaen XSL-muunnoksia rajapintoihin ja yksinkertaisia liittymi� asiakaan ERP-j�rjestelmien ja Itellan varastonhallintaj�rjestelm�n (WMS) v�lille. Olin mukana my�s erillisiss� JAVA-projekteissa ja toimin liittym�tukiteht�viss�. Toteutin Itella-konsernin Salesforce CRM:��n lis�moduulin Apexkoodilla. .",
                tarina = "Salesforce-projektissa yll�tin asiakkaan sitkeydell�ni, sain kehitetty� ominaisuuden, jonka onnistumiseen asiakas ei uskonut."
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
            var myObj = new { koulu = "Tampereen Teknillinen Yliopisto", tutkinto = "Diplomi-insin��ri" };
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
