using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace fiteryomin
{

    class Program
    {

        struct Entry
        {
            public string Year;
            public string City;
            public string Country;

            public Entry(string year = "", string city = "", string country = "")
            {
                Year = year;
                City = city;
                Country = country;
            }

            public override string ToString()
            {
                return Year + " " + City + " " + Country;
            }
        }



        static void Main()
        {
            string[] data = File.ReadAllLines("a.txt");
            List<Entry> entries = new List<Entry>();

            foreach(var e in data)
            {
                var elements = e.Split();
                entries.Add(new Entry(elements[0], elements[1], elements[2]));
            }

            // распределение по годам
            StringBuilder sb = new StringBuilder();
            foreach(var e in entries.GroupBy(e => e.Year))
                foreach(var i in e)
                    sb.Append(i.ToString() + "\n");            
            File.WriteAllText("1.txt", sb.ToString());


            // рапределение по городу рождения 
            sb.Clear();
            var el = entries.GroupBy(e => e.City);
            foreach (var e in el)
                foreach (var i in e)
                    sb.Append(i + "\n");
            File.WriteAllText("2.txt", sb.ToString());


            // распределение по стране
            Console.WriteLine("Выберите страну. Варианты: ");

            HashSet<string> countries = new HashSet<string>();
            entries.ForEach(e => countries.Add(e.Country));
            foreach (var e in countries)
                Console.WriteLine(e);

            sb.Clear();
            string country = Console.ReadLine();
            foreach (var e in entries.FindAll(e => e.Country == country))
                sb.Append(e + "\n");

            File.WriteAllText("3.txt", sb.ToString());
        }

    }

}

