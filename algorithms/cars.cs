using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main() 
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];
            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine("Год выпуска");
                int birth = int.Parse(Console.ReadLine());
                Console.WriteLine("Цвет");
                string color = Console.ReadLine();
                Console.WriteLine("Марка");
                string mark = Console.ReadLine();
                Console.WriteLine("ФИО");
                string fio = Console.ReadLine();
                Console.WriteLine("Год последнего тех. осмотра");
                int tech = int.Parse(Console.ReadLine());

                cars[i] = new Car(birth, color, mark, fio, tech);
            }

            Console.WriteLine("Введите год");
            int year = int.Parse(Console.ReadLine());
            foreach (var c in cars)
                if (c.BirthYear == year) Console.WriteLine(c.ToString());

            Console.WriteLine("Введите марку");
            string marka = Console.ReadLine();
            foreach (var c in cars)
                if (c.Mark == marka) Console.WriteLine(c.ToString());

            Console.WriteLine("Введите год прохождения то");
            int lasttech = int.Parse(Console.ReadLine());
            foreach (var c in cars)
                if (c.Tech == lasttech) Console.WriteLine(c.ToString());

            Console.WriteLine("Введите ФИО");
            string lastfio = Console.ReadLine();
            foreach (var c in cars)
                if (c.Fio == lastfio) Console.WriteLine(c.ToString());
        }

    }

    /*
     * работа с классами, второй класс пока здесь же
     * дан класс машины, в котором описываются поля
     * год выпуска, цвет, марка, фио владельцаб год прохождения то
     * реализовать выборку машин по году, по наименованию марки, 
     * по году прохождения то, выдать все данные по фио владельца
     * свойства, методы, конструкторы
     */

    class Car 
    {
        public int BirthYear { get; set; }
        public string Color { get; set; }
        public string Mark { get; set; }
        public string Fio { get; set; }
        public int Tech { get; set; }

        public Car(int birth, string color, string mark, string fio, int tech)
        {
            BirthYear = birth;
            Color = color;
            Mark = mark;
            Fio = fio;
            Tech = tech;
        }

        public string ToString() 
        {
            return BirthYear + " " + Color + " " + Mark + " " + Fio + " " + Tech;
        }
    }
}

