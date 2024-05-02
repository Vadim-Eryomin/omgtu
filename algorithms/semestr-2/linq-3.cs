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
            string[] data = new string[] { "12345", "123456789", "1234567", "12345678", "1234567", "123456789", "1234", "12345678" };
            for (int i = 0; i < 2; i++)
            {
                data
                    .Where(e => e.Length % 2 == 0)
                    .ToList()
                    .ForEach(e => Console.Write(e + " "));
                Console.WriteLine();

                data = data.Where((e, index) => index % 2 == 0).ToArray();
            }
        }
    }
}
