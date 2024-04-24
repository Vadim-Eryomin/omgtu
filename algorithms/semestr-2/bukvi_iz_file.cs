using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eryominfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("a.txt");
            SortedDictionary<char, int> letterCounts = new SortedDictionary<char, int>();
          
            foreach (char sym in data)
                letterCounts.Incr(sym);         
   
            letterCounts.Show();
            Console.WriteLine("Чаще всего " + letterCounts.First(e => e.Value == letterCounts.Max(ei => ei.Value)).Key);
            Console.WriteLine("Уникальных " + letterCounts.Keys.Count);
            Console.WriteLine("Символы " + letterCounts.Keys.Aggregate<char, string>("", (str, ch) => str += ch));
        }
    }

    static class Extension
    {
        public static void Incr(this SortedDictionary<char, int> dict, char key)
        {
            if (key == 10 || key == 13) return;

            if (!dict.ContainsKey(key))
            {
                dict[key] = 1;
            }
            else
            {
                dict[key] = dict[key] + 1;
            }
        }

        public static void Show(this SortedDictionary<char, int> dict)
        {
            foreach (var entry in dict)
                Console.WriteLine(entry.Key + " " + entry.Value);
        }

    }
}

