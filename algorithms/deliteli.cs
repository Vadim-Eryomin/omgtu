using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        /*
         * 
         * 
         * 
         */
        static void Main() 
        {
            for (int i = 106732567; i < 152673837; i++)
            {
                bool flag = true;

                if (((int)Math.Sqrt(i) * (int)Math.Sqrt(i)) != i)
                {
                    continue;
                }

                int dels = 0;
                int max = 0;

                for (int j = 2; j < (int)(Math.Sqrt(i) - 1); j++)
                {
                    if (i % j == 0)
                    {
                        dels += 2;
                        max = i / j;
                    }
                    if (dels > 2)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && dels == 2)
                {
                    Console.WriteLine(i + " " + max);
                }

            }

            Console.ReadKey();

        }
      
    }
}
