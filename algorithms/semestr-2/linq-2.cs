using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int NumberSum(int number) {
            return number.ToString().ToArray().Aggregate<char, int>(0, (sum, el) => sum += int.Parse(el + ""));
        }

        static void Main(string[] args)
        {
            int[] elements = new int[] { 15, 123, 465, 1231, 456, 123, 49, 564, 376 };
            elements
                .Where(e => NumberSum(e) % 2 == 0)
                .ToList()
                .ForEach(e => Console.Write(e + " "));
        }
    }
}
