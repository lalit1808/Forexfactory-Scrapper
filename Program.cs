using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using HtmlAgilityPack;

namespace ConsoleApplication5
{
    class Program
    {
         
        static void Main(string[] args)
        {
            string dt;
            System.Console.WriteLine("Enter the date");

            dt = Convert.ToString(Console.ReadLine());
            
            string yy = dt.Substring(dt.Length - 4);
            int year = Convert.ToInt16(yy);

            var myTask= MainAsync(dt);

            CalendarEvent.yy = year;
            CalendarEvent.object_count = 0;
            string result = myTask.Result;

            new Class1().Parset(result);
            
             

            

            Console.ReadLine();
        }
        private static readonly HttpClient client = new HttpClient();
        static async Task<string> MainAsync(string dt)
        {
            // ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
               ServicePointManager.Expect100Continue = true;
               ServicePointManager.DefaultConnectionLimit = 9999;
               ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            string newdate = dt ;
            var values = new Dictionary<string, string>
    {               { "s",""},
                  { "securitytoken", "guest"},
                  { "do", "saveoptions" },
                  { "setdefault","no" },
                  { "ignoreinput","no" },
                  { "flex[Calendar_mainCal][idSuffix]","" },
                  { "flex[Calendar_mainCal][_flexForm_]","flexForm" },
                  { "flex[Calendar_mainCal][modelData]","YToxMjp7czoxMToicGFfY29udHJvbHMiO3M6MTc6ImNhbGVuZGFyfENhbGVuZGFyIjtzOjE2OiJwYV9pbmplY3RyZXZlcnNlIjtiOjA7czoxNjoicGFfaGFyZGluamVjdGlvbiI7YjowO3M6MTE6InBhX2luamVjdGF0IjtiOjA7czoxNDoidmlld2luZ0RlZmF1bHQiO3M6OToiVGhpcyBXZWVrIjtzOjExOiJwcmV2Q2FsTGluayI7czoxNDoiZGF5PWp1bjI1LjIwMTciO3M6MTE6Im5leHRDYWxMaW5rIjtzOjE0OiJkYXk9anVuMjcuMjAxNyI7czo3OiJwcmV2QWx0IjtzOjI3OiJKdW4gMjUsIDIwMTcgLSBKdW4gMjYsIDIwMTciO3M6NzoibmV4dEFsdCI7czoyNzoiSnVuIDI3LCAyMDE3IC0gSnVuIDI4LCAyMDE3IjtzOjEwOiJuZXh0SGlkZGVuIjtiOjA7czoxMDoicHJldkhpZGRlbiI7YjowO3M6OToicmlnaHRMaW5rIjtOO30=" },
                  { "flex[Calendar_mainCal][begindate]", newdate },
                  { "flex[Calendar_mainCal][enddate]","July 7, 2017" },
                  { "flex[Calendar_mainCal][calendardefault]","thisweek" },
                  { "flex[Calendar_mainCal][impacts][high]","high" },
                  { "flex[Calendar_mainCal][impacts][medium]","medium" },
                  { "flex[Calendar_mainCal][impacts][low]","low" },
                  { "flex[Calendar_mainCal][impacts][holiday]","holiday" },
                  { "flex[Calendar_mainCal][_cbarray_]","1" },
                  { "flex[Calendar_mainCal][eventtypes][growth]","growth" },
                  { "flex[Calendar_mainCal][eventtypes][inflation]","inflation" },
                  { "flex[Calendar_mainCal][eventtypes][employment]","employment" },
                  { "flex[Calendar_mainCal][eventtypes][centralbank]","centralbank" },
                  { "flex[Calendar_mainCal][eventtypes][bonds]","bonds" },
                  { "flex[Calendar_mainCal][eventtypes][housing]","housing" },
                  { "flex[Calendar_mainCal][eventtypes][sentiment]","sentiment" },
                  { "flex[Calendar_mainCal][eventtypes][pmi]","pmi" },
                  { "flex[Calendar_mainCal][eventtypes][speeches]","speeches" },
                  { "flex[Calendar_mainCal][eventtypes][misc]","misc"},
                  { "flex[Calendar_mainCal][currencies][aud]","aud" },
                  { "flex[Calendar_mainCal][currencies][cad]","cad" },
                  { "flex[Calendar_mainCal][currencies][chf]","chf" },
                  { "flex[Calendar_mainCal][currencies][cny]","cny" },
                  { "flex[Calendar_mainCal][currencies][eur]","eur" },
                  { "flex[Calendar_mainCal][currencies][gbp]","gbp" },
                  { "flex[Calendar_mainCal][currencies][jpy]","jpy"  },
                  { "flex[Calendar_mainCal][currencies][nzd]","nzd" },
                  { "flex[Calendar_mainCal][currencies][usd]","usd" },
                  {"false" ,""}

    };       
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://www.forexfactory.com/flex.php?", content);

            var responseString = await response.Content.ReadAsStringAsync();
          //       Console.WriteLine(responseString);
            //     return  responseString;
            
            return responseString;

        }

    }
}
