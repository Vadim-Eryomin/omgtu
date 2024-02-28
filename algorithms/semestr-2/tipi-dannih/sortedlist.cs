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
            SortedList list = new SortedList();

            while (true)
            {
                int choice = ShowMenu();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ключ:");
                        object key = Console.ReadLine();
                        Console.WriteLine("Введите значение:");
                        object value = Console.ReadLine();
                        list.Add(key, value);
                        break;
                    case 2:
                        Console.WriteLine("Введите ключ");
                        key = Console.ReadLine();
                        int index = list.IndexOfKey(key);
                        if (index == -1)
                            Console.WriteLine("Такого ключа нет!");
                        else
                            Console.WriteLine("Индекс ключа - " + index);
                        break;
                    case 3:
                        Console.WriteLine("Введите значение");
                        value = Console.ReadLine();
                        index = list.IndexOfValue(value);
                        if (index == -1)
                            Console.WriteLine("Такого значения нет!");
                        else
                            Console.WriteLine("Индекс значения - " + index);
                        break;
                    case 4:
                        Console.WriteLine("Введите ключ");
                        key = Console.ReadLine();
                        index = list.IndexOfKey(key);
                        
                        if (index == -1)
                            Console.WriteLine("Такого ключа нет!");
                        else
                        {
                            value = list.GetByIndex(index);
                            Console.WriteLine("Значение - " + value);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Введите значение");
                        value = Console.ReadLine();
                        index = list.IndexOfValue(value);
                        if (index == -1)
                            Console.WriteLine("Такого значения нет!");
                        else
                        {
                            key = list.GetKey(index);
                            Console.WriteLine("Ключ для значения - " + key);
                        }
                        break;
                    case 6:
                        for (int k = 0; k < list.Count; k++)
                        {
                            Console.WriteLine(list.GetKey(k) + " " + list.GetByIndex(k));
                        }
                        break;
                    case 7:
                        return;
                }

                Console.ReadKey();
                Console.Clear();
            }
            
        }

        static int ShowMenu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1 - добавить элемент");
            Console.WriteLine("2 - индекс ключа");
            Console.WriteLine("3 - индекс значения");
            Console.WriteLine("4 - найти значение по ключу");
            Console.WriteLine("5 - найти ключ по значению");
            Console.WriteLine("6 - вывести массив");
            Console.WriteLine("7 - выход");
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
