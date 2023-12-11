using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{

    class Program
    {

        static void Main()
        {
            string pattern = Console.ReadLine();
            int count = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "") break;
                line = line.Replace(pattern, "*");
                count += line.Count(e => e == '*');
            }

            Console.WriteLine(count);
            Console.ReadKey();
        }
        
    }
}

