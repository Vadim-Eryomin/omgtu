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
        static string nAs(int n)
        {
            StringBuilder As = new StringBuilder();
            for (int i = 0; i < n; i++)
                As.Append("a");
            return As.ToString();
        }

        static void Main() 
        {
            string[] data = File.ReadAllLines("a.txt").Where(s => s.Contains("a")).ToArray();
            if (data.Length == 0)
            {
                Console.WriteLine("Нет букв а");
                return;
            }
                

            int[] countAs = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                while (line.Contains("a"))
                {
                    for (int j = 0; j < line.Length + 1; j++)
                    {
                        if (line.Contains(nAs(j))) countAs[i] = j;
                        else 
                        {
                            line = line.Replace(nAs(j - 1), "*");
                        };
                    }
                }
            }


            int min = countAs.Min();
            if (min == 0)
                Console.WriteLine("Нет букв а");
            else
            {
                int index = Array.IndexOf(countAs, min);
                Console.WriteLine(data[index]);
            }
        }

    }

}

