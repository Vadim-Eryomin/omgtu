using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fiteryomin
{
    class Programm
    {
        class Call
        {
            public string phone;
            public int day;
            public string startPhoneTime;
            public int minutes;
        }

        static void Main()
        {
            Queue<Call> calls = new Queue<Call>();
            Hashtable phoneToMinutes = new Hashtable();
            Hashtable dateToMinutes = new Hashtable();
            Dictionary<string, int> phoneToMinutesDict = new Dictionary<string,int> ();
            Dictionary<int, int> dateToMinutesDict = new Dictionary<int,int>();

            while (true)
            {
                switch (GetChoice())
                {
                    case 1: 
                        var call = new Call();
                        GetLine(out call);
                        calls.Enqueue(call);
                        break;
                    case 2:
                        ProcessQueue(calls, phoneToMinutes, dateToMinutes, phoneToMinutesDict, dateToMinutesDict);
                        Console.WriteLine("Отчет из хэш-таблицы: ");
                        foreach (DictionaryEntry e in phoneToMinutes)
                            Console.WriteLine(e.Key + "  " + e.Value);

                        Console.WriteLine("Отчет из словаря: ");
                        foreach (KeyValuePair<string, int> e in phoneToMinutesDict)
                            Console.WriteLine(e.Key + "  " + e.Value);
                        break;
                    case 3:
                        ProcessQueue(calls, phoneToMinutes, dateToMinutes, phoneToMinutesDict, dateToMinutesDict);
                        Console.WriteLine("Отчет из хэш-таблицы: ");
                        foreach (DictionaryEntry e in dateToMinutes)
                            Console.WriteLine(e.Key + "  " + e.Value);

                        Console.WriteLine("Отчет из словаря: ");
                        foreach (KeyValuePair<int, int> e in dateToMinutesDict)
                            Console.WriteLine(e.Key + "  " + e.Value);
                        break;
                    case 4:
                        return;

                }
                Console.WriteLine("\nОперация выполнена");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ProcessQueue(Queue<Call> calls, Hashtable phoneToMinutes, Hashtable dateToMinutes, Dictionary<string, int> phoneToMinutesDict, Dictionary<int, int> dateToMinutesDict)
        {
            while (calls.Count > 0)
            {
                var call = calls.Dequeue();
                if (call.minutes == -1)
                    continue;

                if (phoneToMinutes.Contains(call.phone)) phoneToMinutes[call.phone] = (int)(phoneToMinutes[call.phone]) + call.minutes;
                else phoneToMinutes.Add(call.phone, call.minutes);

                if (dateToMinutes.Contains(call.day)) dateToMinutes[call.day] = (int)(dateToMinutes[call.day]) + call.minutes;
                else dateToMinutes.Add(call.day, call.minutes);

                if (phoneToMinutesDict.ContainsKey(call.phone)) phoneToMinutesDict[call.phone] += call.minutes;
                else phoneToMinutesDict.Add(call.phone, call.minutes);

                if (dateToMinutesDict.ContainsKey(call.day)) dateToMinutesDict[call.day] += call.minutes;
                else dateToMinutesDict.Add(call.day, call.minutes);

            }
        }

        static int GetChoice()
        {
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Внести звонок");
            Console.WriteLine("2. Месячный отчет по сумме минут каждого номера");
            Console.WriteLine("3. Суммарное время за каждую дату");
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

        static void GetLine(out Call call)
        {
            call = new Call();

            try
            {
                Console.WriteLine("На какой телефон звонили?");
                call.phone = Console.ReadLine();
                Console.WriteLine("Какого числа был разговор?");
                call.day = int.Parse(Console.ReadLine());
                if (call.day <= 0 || call.day >= 32) throw new Exception("День неправильный");
                Console.WriteLine("Когда позвонили?");
                call.startPhoneTime = Console.ReadLine();
                Console.WriteLine("Сколько минут длился вызов?");
                call.minutes = int.Parse(Console.ReadLine());
                if (call.minutes <= 0) throw new Exception("Мало разговаривали");
            }
            catch (Exception e)
            {
                call.phone = call.startPhoneTime = null;
                call.day = call.minutes = -1;
                Console.WriteLine("Произошла ошибка: " + e.Data);
            }
        }
    }
}
