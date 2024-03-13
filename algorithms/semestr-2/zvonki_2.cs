using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fiteryomin
{
    class Call
    {
        public string from;
        public string to;
        public string date;
        public int minutes;

        public Call(string from, string to, string date, int minutes)
        {
            this.from = from;
            this.to = to;
            this.date = date;
            this.minutes = minutes;
        }
    }

    class Programm
    {


        static void Main()
        {
            Hashtable calls = new Hashtable();
            while (true)
            {
                int choice = GetChoice();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Кто звонил: ");
                        string phoneFrom = Console.ReadLine();
                        Console.WriteLine("Кому звонил: ");
                        string phoneTo = Console.ReadLine();
                        Console.WriteLine("Дата разговора: ");
                        string date = Console.ReadLine();
                        int minutes = 0;
                        try
                        {
                            Console.WriteLine("Сколько разговаривали (в минутах): ");
                            minutes = int.Parse(Console.ReadLine());
                            if (minutes <= 0)
                            {
                                Console.WriteLine("Мало разговаривали");
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка");
                        }

                        if (!calls.Contains(date))
                            calls.Add(date, new List<Call>());

                        ((List<Call>)calls[date]).Add(new Call(phoneFrom, phoneTo, date, minutes));
                        break;

                    case 2:
                        Console.WriteLine("Кто звонил: ");
                        string phone = Console.ReadLine();
                        Hashtable times = new Hashtable();

                        foreach (DictionaryEntry a in calls)
                        {
                            foreach (Call call in ((List<Call>)a.Value))
                            {
                                if (!times.Contains(call.to)) times.Add(call.to, 0);
                                if (call.from == phone)
                                    times[call.to] = ((int)times[call.to]) + 1;
                            }

                            int maxCount = int.MinValue;
                            string maxPhone = "";

                            foreach(DictionaryEntry e in times) {
                                if (maxCount < ((int)e.Value))
                                {
                                    maxCount = (int) e.Value;
                                    maxPhone = (string) e.Key;
                                }
                            }
                            Console.WriteLine("Дата: " + a.Key + " звонил раз: " + maxCount + " телефон: " + maxPhone);
                        }

                        break;

                    case 3:
                        Console.WriteLine("Кто звонил: ");
                        phone = Console.ReadLine();
                        times = new Hashtable();

                        foreach (DictionaryEntry a in calls)
                        {
                            foreach (Call call in ((List<Call>)a.Value))
                            {
                                if (!times.Contains(call.to)) times.Add(call.to, 0);
                                if (call.from == phone)
                                    times[call.to] = ((int)times[call.to]) + call.minutes;
                            }

                            int maxCount = int.MinValue;
                            string maxPhone = "";

                            foreach (DictionaryEntry e in times)
                            {
                                if (maxCount < ((int)e.Value))
                                {
                                    maxCount = (int)e.Value;
                                    maxPhone = (string)e.Key;
                                }
                            }
                            Console.WriteLine("Дата: " + a.Key + " звонил минут: " + maxCount + " телефон: " + maxPhone);
                        }

                        break;

                    case 4:
                        return;

                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static int GetChoice()
        {
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Внести звонок");
            Console.WriteLine("2. Кому чаще звонили");
            Console.WriteLine("3. С кем дольше говорили");
            Console.WriteLine("4. Выход");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
    }
}

