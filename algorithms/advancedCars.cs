using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{

    class Program
    {
        static void Main() 
        {
            Car audi = new Car("Audi", "Gray", 1);
            audi.AddTechView(2000, 2004, 2005, 2015);
            audi.AddUser("Вася Пупкин");

            Car mercedes = new Car("Mercedes", "Black", 2);
            mercedes.AddTechView(2015, 2020, 2023);
            mercedes.AddUser("Петя", "Сергей Казаков");

            Car porche = new Car("Porche", "Black", 3);
            porche.AddTechView(2014, 2020, 2022);
            porche.AddUser("Никита Харлов", "Николай Семикин");

            Car cherry = new Car("Cherry", "Green", 4);
            cherry.AddTechView(2015, 2020, 2021);
            cherry.AddUser("Егор Шелехов");

            Car[] cars = { audi, mercedes, porche, cherry };

            
            try
            {
                Console.Write("Введите номер двигателя: ");
                int engine = int.Parse(Console.ReadLine());
                Console.WriteLine(cars[engine - 1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Вводите число!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Нет такой машины!");
            }

            Console.Write("Введите год тех. осмотра: ");
            string year = Console.ReadLine();
            foreach (var car in cars)
                car.TestYear(year);

            Console.WriteLine("Единственный владелец у машин: ");
            foreach (var car in cars)
                car.TestOnlyUser();

            Console.ReadKey();
        }

    }

    class Car 
    {
        string[] TechView { get; set; }
        string Name { get; set; }
        string[] Users { get; set; }
        string Color { get; set; }
        int EngineNumber { get; set; }

        int lastTechView = 0;
        int lastUser = 0;

        public void AddTechView(params int[] year) 
        {
            foreach(var p in year)
                TechView[lastTechView++] = "" + p;
        }

        public void AddUser(params string[] user) 
        {
            foreach(var u in user)
                Users[lastUser++] = u;
        }

        public void TestOnlyUser() 
        {
            if (Users.Count(e => e != null) == 1)
                Console.WriteLine(this.ToString());
        }

        public void TestYear(string year) 
        {
            if (TechView.Contains(year))
            {
                Console.WriteLine(ToString());
            }
        }
        

        public Car(string name, string color, int engineNumber) 
        {
            Color = color;
            Name = name;
            EngineNumber = engineNumber;

            Users = new string[6];
            TechView = new string[6];
        }

        public override string ToString()
        {
            string s = "Name: " + Name + ", Color: " + Color + ", Engine: " + EngineNumber + ", ";
            s += "Users: [" + Users.Aggregate((cumul, e) => e != null ? cumul + ", " + e : cumul) + "], ";
            s += "Tech Views: [" + TechView.Aggregate((cumul, e) => e != null ? cumul + ", " + e : cumul) + "]";
            return s;
        }

        public string ListOfUsers() 
        {
            return "Users of " + Name + ": [" + Users.Aggregate((cumul, e) => e != null ? cumul + ", " + e : cumul) + "]";
        }
        
    }
}

