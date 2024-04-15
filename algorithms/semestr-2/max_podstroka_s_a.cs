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
            string[] data = File.ReadAllLines("a.txt");
            int[] countAs = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line.Contains(nAs(j))) countAs[i] = j;
                    else break;
                }
            }

            int max = countAs.Max();
            if (max == 0)
                Console.WriteLine("Нет букв а");
            else
            {
                int index = Array.IndexOf(countAs, max);
                Console.WriteLine(data[index]);
            }
        }

    }

}

