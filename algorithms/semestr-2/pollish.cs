using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fiteryomin
{
    class Programm
    {
        static void Main()
        {
            string eval = Console.ReadLine(); // "1 2 + 5 * 4 /"
            Stack numbers = new Stack();
            foreach (var e in eval.Split(' '))
            {
                if (e == "+" || e == "*" || e == "-" || e == "/")
                {
                    if (numbers.Count < 2)
                    {
                        Console.WriteLine("Недостаточно операндов!");
                        Console.ReadKey();
                        return;
                    }

                    
                    double a = (double)numbers.Pop(), b = (double)numbers.Pop();
                    if (e == "/" && a == 0)
                    {
                        Console.WriteLine("Делить на ноль нельзя!");
                        Console.ReadKey();
                        return;
                    }

                    numbers.Push(Operate(b, a, e));
                }
                else
                {
                    try
                    {
                        numbers.Push(double.Parse(e));
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка чтения данных");
                    }
                }
            }

            Console.WriteLine(numbers.Pop());
            Console.ReadKey();
        }

        static double Operate(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("Деление на ноль невозможно!");
                        return 0;
                    }
                    return a / b;
            }
            return 0;
        }
    }
}
