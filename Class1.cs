using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleApplication5
{
    class Class1
    {
       
        List<CalendarEvent> values = new List<CalendarEvent>();
        List<string> data = new List<string>();
        public string Parset(string responseString)
        {
            
            var doc = new HtmlDocument();
            doc.LoadHtml(responseString);
            
            var rows = doc.DocumentNode.SelectNodes("//flexmulti/flex/table/tr");
            rows.RemoveAt(0);
            
          
            
            foreach (var row in rows)
            {
               
                var nodes = row.SelectNodes("//tr/td[@class='calendar__row calendar__expand']");
                if (nodes != null)
                    foreach (var node in nodes)
                        node.Remove();

                var nodes1 = row.SelectNodes("//td[@class='calendar__cell']");
                if (nodes1 != null)
                    foreach (var node in nodes1)
                        node.Remove();

                var columns = row.SelectNodes("td");

                if (columns != null)
                    foreach (var column in columns)
                    {

                        var temps = column.SelectNodes("div/span/@title");
                        string item;

                        if (temps != null)
                        {
                            foreach (var temp in temps)
                            {
                                HtmlAttribute attribute = temp.Attributes["title"];
                                item = attribute.Value;
                                CalendarEvent.item1 = item;

                                // temp.Attributes.Where(a => a.Name.Equals("Title", StringComparison.InvariantCultureIgnoreCase)).ToList().ForEach(a => Console.WriteLine("\tImpact Value: {0}", a.Value.Trim()));                                   
                            }
                        }
                        data.Add(column.InnerText.Trim());

                        //Console.WriteLine("\tColumn Value: {0} ", column.InnerText.Trim());

                    }
               
                if (data.Count > 2)
                { new CalendarEvent(data); }
                data.Clear();
            }
            return "";
        }

    }
}
