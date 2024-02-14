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
            Random r = new Random();
            Array ar = Array.CreateInstance(typeof(int), 10);
            for (int i = 0; i < 10; i++)
            {
                ar.SetValue(r.Next(1, 10), i);
            }

            bool dirty = true;
            while (true)
            {
                int choice = ShowMenu();
                if (choice == -1)
                {
                    Console.Clear();
                    continue;
                }
                    

                if (choice == 5)
                    break;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите индекс");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите значение");
                        int value = int.Parse(Console.ReadLine());

                        try
                        {
                            ar.SetValue(value, index);
                            dirty = true;
                        }
                        catch
                        {
                            Console.WriteLine("Что-то не так!");
                        }
                        break;

                    case 2:
                        dirty = false;
                        Array.Sort(ar);
                        break;

                    case 3:
                        Print(ar);
                        break;

                    case 4:
                        if (dirty)
                        {
                            Console.WriteLine("Массив не отсортирован!");
                            break;
                        }
                        try {
                            value = int.Parse(Console.ReadLine());
                            index = Array.BinarySearch(ar, value);
                            if (index < 0)
                                Console.WriteLine("Не найдено");
                            else
                                Console.WriteLine("Найден на индексе " + index);
                            
                        } catch {
                            Console.WriteLine("что-то не так!");
                        }

                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static int ShowMenu() {
            Console.WriteLine("Меню");
            Console.WriteLine("1 - изменить элемент");
            Console.WriteLine("2 - отсортировать");
            Console.WriteLine("3 - вывести");
            Console.WriteLine("4 - бинарный поиск");
            Console.WriteLine("5 - выход");
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

        static void Print(Array a)
        {
            foreach (var e in a)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
        }
    }



}
