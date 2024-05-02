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
            int[] elements = new int[] { 15, 123, 465, 1231, 456, 123, 49, 564, 376 };
            elements
                .Where(e => e % 10 % 3 == 0)
                .ToList()
                .ForEach(e => Console.Write(e + " "));
        }
    }
}
