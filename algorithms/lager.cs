using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{

    class Program
    {

        static void Main()
        {
            float speed = GetFloat("Скорость км/ч: ") * 1000 / 60; // in meters/min
            int number = (int) GetFloat("Количество пунктов: ");
            float[] ps = new float[number + 1];
            ps[0] = 0;

            for (int i = 1; i <= number; i++)
                ps[i] = GetFloat("Расстояние км: ") * 1000; // in meters

            float startHour = GetFloat("Часы восхода: ");
            float startMinutes = GetFloat("Минуты восхода: ");
            float endHour = GetFloat("Часы заката: ");
            float endMinutes = GetFloat("Минуты захода: ");

            startMinutes += startHour * 60;
            endMinutes += endHour * 60;

            float dayTime = endMinutes - startMinutes;
            
            float thisDay = dayTime;
            int days = 1;
            int[] stops = new int[number];
            int index = 0;

            for (int i = 1; i <= number; i++)
            {
                if (thisDay <= (ps[i] - ps[i - 1]) / speed)
                {
                    stops[index++] = i - 1;
                    days += 1;
                    thisDay = dayTime - (ps[i] - ps[i - 1]) / speed;
                }
                else
                {
                    thisDay -= (ps[i] - ps[i - 1]) / speed;
                }
                    
            }

            foreach (var e in stops)
                Console.Write(e + " ");
            Console.WriteLine("\n " + days + " дней");
            Console.ReadLine();
        }

        public static float GetFloat(string prompt)
        {
            Console.Write(prompt);
            return float.Parse(Console.ReadLine());
        }
    }

}

