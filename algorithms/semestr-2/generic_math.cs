using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fiteryomin
{

    class Program
    {

        static void Main()
        {
            Calc<int> calculatorInt = new Calc<int>();
            Console.WriteLine(calculatorInt.Sum(5, 80));
            Console.WriteLine(calculatorInt.Diff(90, 6));

            Calc<double> calculatorDouble = new Calc<double>();
            Console.WriteLine(calculatorDouble.Mul(5, 6));
            Console.WriteLine(calculatorDouble.Div(90, 6));
        }

    }

    class Calc<T>
    {
        T a;
        T b;

        public T Sum(T a, T b)
        {
            dynamic c = a;
            dynamic d = b;
            return c + d;
        }

        public T Diff(T a, T b)
        {
            dynamic c = a;
            dynamic d = b;
            return c - d;
        }

        public T Mul(T a, T b)
        {
            dynamic c = a;
            dynamic d = b;
            return c * d;
        }

        public T Div(T a, T b)
        {
            dynamic c = a;
            dynamic d = b;
            return c / d;
        }


    }

}

