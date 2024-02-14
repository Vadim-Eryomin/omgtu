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
            ArrayList ar = new ArrayList();

            bool dirty = true;
            while (true)
            {
                int choice = ShowMenu();
                if (choice == -1)
                {
                    Console.Clear();
                    continue;
                }

                if (choice == 6)
                    break;

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Введите индекс");
                            int index = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите значение");
                            object e = Console.ReadLine();
                            ar[index] = e;
                            dirty = true;
                        }
                        catch
                        {
                            Console.WriteLine("Проблемс");
                        }
                        
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Введите значение");
                            object el = Console.ReadLine();
                            ar.Add(el);
                        }
                        catch
                        {
                            Console.WriteLine("Проблемс!");
                        }
                        
                        break;

                    case 3:
                        ar.Sort();
                        dirty = false;
                        break;

                    case 4:
                        foreach (var e in ar)
                        {
                            Console.Write(e + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        if (dirty)
                        {
                            Console.WriteLine("Не отсортирован!");
                            break;
                        }

                        object elem = Console.ReadLine();
                        int ind = ar.BinarySearch(elem);
                        if (ind < 0) Console.WriteLine("Не найдено!");
                        else Console.WriteLine("Найдено на индексе " + ind);     
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static int ShowMenu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1 - изменить элемент");
            Console.WriteLine("2 - добавить элемент");
            Console.WriteLine("3 - отсортировать");
            Console.WriteLine("4 - вывести");
            Console.WriteLine("5 - бинарный поиск");
            Console.WriteLine("6 - выход");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неправильный ввод данных");

                return -1;
            }
        }
    }
}
