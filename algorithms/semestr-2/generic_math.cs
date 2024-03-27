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
            Calc<int> calculator = new Calc<int>();
        }

    }

    class Calc<T>
    {
        T a;
        T b;

        public T Sum(T a, T b)
        {
            return a + b;
        }


    }

}

