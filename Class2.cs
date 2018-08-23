using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication5
{

    class CalendarEvent
    {
        private List<string> asd;

        int dd, mm, count, count1, count2, count3, num;
        public static int yy;

        public static string datestring, dateTime, item1;

        public DateTime Date { set; get; }
        public string Currency { set; get; }
        public string Name { set; get; }
        public string Details { set; get; }
        public string Impact { set; get; }
        public decimal Actual { set; get; }
        public decimal Previous { set; get; }
        public decimal Forecast { set; get; }

       
       
        public CalendarEvent(List<string> asd)
        {
           
                this.asd = asd;
      
              
                //Date Values

                String date = asd.ElementAt(0);
                int length_date = date.Length;
                if (length_date != 0)
                {
                    char[] date_array=date.ToCharArray();
                    char[] m = new char[3];
                    m[0] = date_array[3];
                    m[1] = date_array[4];
                    m[2] = date_array[5];

                    string month = new string(m);
                    string format = "MMM";
                    mm = DateTime.ParseExact(month, format, CultureInfo.InvariantCulture).Month;

                    if (length_date == 8)
                    {
                        dd = (int)Char.GetNumericValue(date_array[7]);
                    }

                    else if (length_date == 9)
                    {
                        char[] d = new char[2];
                        d[0] = date_array[7];
                        d[1] = date_array[8];
                        dd = (int)Char.GetNumericValue(d[0]) * 10;
                        dd = dd + (int)Char.GetNumericValue(d[1]);
                    }

                    else if (dd == 1 && mm == 01)
                        yy++;

                    count = 0;

                    Date = new DateTime(yy, mm, dd);
                    count++;
                    datestring = Date.ToString("yyyy-MM-dd");

                }
                //Time Values

                string time = asd.ElementAt(1);
                int length_time = time.Length;
                if (length_time != 0)
                {
                    if (time[0] != 'A' && time[0] != 'D' && time[0] != 'T')
                    {
                        time = time.ToUpper();

                        string insertedStr = time.Insert(length_time - 2, " ");

                        time = insertedStr;

                        dateTime = datestring + " " + time;
                        count--;

                        Date = DateTime.Parse(dateTime);

                        Console.WriteLine("Date: {0}", Date);

                    }
                    else
                    {
                        if (count == 1)
                        {
                            Console.WriteLine("Date: {0}", Date);
                        }
                        else
                        {
                            Date = DateTime.Parse(datestring);
                            Console.WriteLine("Date:{0}", Date);
                        }
                    }

                }
                else
                {
                    Date = Convert.ToDateTime(dateTime);
                    Console.WriteLine("Date: {0}", Date);
                }

                //Currency Values

                Currency = asd.ElementAt(2);
                Console.WriteLine("\tCurrency: {0}", Currency);

                if (Currency.Length != 0)
                {
                    Impact = item1; //Impact Values
                    Console.WriteLine("\tImpact  : {0}", Impact);
                }
                else
                {
                    Impact = ""; //Impact Values
                    Console.WriteLine("\tImpact  : {0}", Impact);
                }

                //Name Values

                Name = asd.ElementAt(4);
                Console.WriteLine("\tName    : {0}", Name);


                //Actual Values

                string actual = asd.ElementAt(6);
                count = 0;

                if (actual.Contains('-'))
                {
                    num = actual.Count(c => c == '-');

                    if (num >= 2)
                    {
                        string[] ActualSplit = actual.Split('-');

                        actual = ActualSplit[0];
                    }
                    else if (num == 1)
                        count++;
                }

                if (num != 2)
                    actual = Regex.Replace(actual, "[^.0-9]+", "");

                count1 = actual.Count(c => c == '.');

                if (count1 >= 2)
                {
                    int second = IndexOfSecond(actual, ".");
                    actual = actual.Substring(0, second - 1);
                }

                if (actual.Length == 0)
                    Console.WriteLine("\tActual  : {0}", actual);
                else
                {
                    if (count == 1)
                        Actual = Convert.ToDecimal(actual) * -1;

                    else
                        Actual = Convert.ToDecimal(actual);

                    Console.WriteLine("\tActual  : {0}", Actual);
                }


                //Forecast Values

                string forecast = asd.ElementAt(7);
                count = 0;

                if (forecast.Contains('-'))
                {
                    num = forecast.Count(c => c == '-');

                    if (num >= 2)
                    {
                        string[] ForecastSplit = forecast.Split('-');

                        forecast = ForecastSplit[0];

                    }
                    else if (num == 1)
                    {
                        count++;
                    }
                }

                if (num != 2)
                    forecast = Regex.Replace(forecast, "[^.0-9]", "");

                count2 = forecast.Count(c => c == '.');

                if (count2 >= 2)
                {
                    int second = IndexOfSecond(forecast, ".");
                    forecast = forecast.Substring(0, second - 1);
                }

                if (forecast.Length == 0)
                {
                    Console.WriteLine("\tForecast: {0}", forecast);
                }
                else
                {
                    if (count == 1)
                        Forecast = Convert.ToDecimal(forecast) * -1;
                    else
                        Forecast = decimal.Parse(forecast);

                    Console.WriteLine("\tForecast: {0}", Forecast);
                }


                //Previous Values

                string previous = asd.ElementAt(8);
                count = 0;

                if (previous.Contains('-'))
                {
                    num = previous.Count(c => c == '-');

                    if (num >= 2)
                    {
                        string[] PreviousSplit = previous.Split('-');

                        previous = PreviousSplit[0];

                    }
                    else if (num == 1)
                    {
                        count++;
                    }
                }
                if (num != 2)
                    previous = Regex.Replace(previous, "[^.0-9]", "");

                count3 = previous.Count(c => c == '.');

                if (count3 >= 2)
                {
                    int second = IndexOfSecond(previous, ".");
                    previous = previous.Substring(0, second - 1);
                }

                if (previous.Length == 0)
                {
                    Console.WriteLine("\tPrevious: {0}\n", previous);
                }
                else
                {
                    if (count == 1)
                    {
                        Previous = Convert.ToDecimal(previous) * -1;
                    }
                    else
                        Previous = decimal.Parse(previous);

                    Console.WriteLine("\tPrevious: {0}\n", Previous);
                }
            
        }
       

        private int IndexOfSecond(string theString, string v)
        {
            int first = theString.IndexOf(v);

            if (first == -1) return -1;

            return first+1;
        }


    }
}
