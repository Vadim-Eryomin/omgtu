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
            Console.WriteLine("Введите элементы первого множества");
            HashSet<int> firstSet = GetSet();
            Console.WriteLine("Введите элементы второго множества");
            HashSet<int> secondSet = GetSet();
            Console.WriteLine("Введите элементы третьего множества");
            HashSet<int> thirdSet = GetSet();

            HashSet<int> intersect = new HashSet<int>();
            HashSet<int> union = new HashSet<int>();

            foreach (var e in firstSet) intersect.Add(e);
            intersect.IntersectWith(secondSet);
            intersect.IntersectWith(thirdSet);

            union.UnionWith(firstSet);
            union.UnionWith(secondSet);
            union.UnionWith(thirdSet);

            firstSet.SymmetricExceptWith(union);
            secondSet.SymmetricExceptWith(union);
            thirdSet.SymmetricExceptWith(union);

            Log("Пересечение", intersect);
            Log("Объединение", union);
            Log("Дополнение первого", firstSet);
            Log("Дополнение второго", secondSet);
            Log("Дополнение третьего", thirdSet);
            Console.ReadKey();
        }

        static void Log(string before, HashSet<int> set)
        {
            Console.Write(before + " ");
            foreach (var e in set) Console.Write(e + " ");
            Console.WriteLine();
        }

        static HashSet<int> GetSet() {
            Console.WriteLine("Введите элементы множества через пробел");
            string line = Console.ReadLine();
            HashSet<int> set = new HashSet<int>();
            try
            {
                foreach (var e in line.Split(' '))
                    set.Add(int.Parse(e));
            }
            catch
            {
                Console.WriteLine("Где-то не число!");
            }

            return set;
        }
    }
}
