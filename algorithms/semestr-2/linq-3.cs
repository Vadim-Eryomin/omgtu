using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> data = new List<string>(new string[]{ "12345", "123456789", "1234567", "12345678", "1234567", "123456789", "1234", "12345678" });
            var el = from e in data
                     where e.Length % 2 == 0
                     select e;

            foreach (var e in el)
                Console.Write(e + " ");

            Console.WriteLine();
            int i = 1;
            while (i < data.Count)
                data.RemoveAt(i++);

            foreach (var e in el)
                Console.Write(e + " ");
                               
        }
    }
}
