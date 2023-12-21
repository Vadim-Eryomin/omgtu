using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        /*
         * класс животные - имя, год рождения 
         * 
         * для сабачьков - порода, окрас; выборка по породе
         * кощки - порода, окрас; выборка по окрасу; смена породы
         * 
         * заполнение(конструкторы, свойства)
         * 
         */
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>();
            List<Cat> cats = new List<Cat>();
            bool flag = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите операцию");
                Console.WriteLine("1 - создать кошку");
                Console.WriteLine("2 - создать собаку");
                Console.WriteLine("3 - выбрать собак по породе");
                Console.WriteLine("4 - выбрать кошек по окрасу");
                Console.WriteLine("5 - переназвать породу кошек");
                Console.WriteLine("6 - показать всех");
                Console.WriteLine("default - выйти");
                Console.WriteLine();

                try
                {
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            cats.Add(new Cat());
                            break;

                        case 2:
                            dogs.Add(new Dog());
                            break;

                        case 3:
                            Console.Write("Введите породу собаки: ");
                            string breed = Console.ReadLine();
                            foreach (var el in dogs)
                                if (el.isBreed(breed))
                                    Console.WriteLine(el);
                            break;

                        case 4:
                            Console.Write("Введите окраску кошки: ");
                            string color = Console.ReadLine();
                            foreach (var el in cats)
                                if (el.isColor(color))
                                    Console.WriteLine(el);
                            break;

                        case 5:
                            Console.Write("Введите старое название породы: ");
                            var oldOne = Console.ReadLine();
                            Console.Write("Введите новое название породы: ");
                            var newOne = Console.ReadLine();
                            foreach (var el in cats) el.ChangeBreed(newOne, oldOne);
                            break;

                        case 6:
                            Console.WriteLine("Кошки");
                            foreach (var el in cats) Console.WriteLine(el);
                            Console.WriteLine("Собаки");
                            foreach (var el in dogs) Console.WriteLine(el);
                            break;

                        default:
                            flag = false;
                            break;
                    }

                }
                catch
                {
                    flag = false;
                }
            } while (flag);

        }

        class Animal
        {
            public string Name { get; set; }
            public int BirthDate { get; set; }

            public Animal()
            {
                Console.Write("Имя: ");
                this.Name = Console.ReadLine();

                try
                {
                    Console.Write("Год рождения: ");
                    this.BirthDate = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, установлено значение по умолчанию");
                    this.BirthDate = 2020;
                }
            }
        }

        class Dog : Animal
        {

            public string Color { get; set; }
            public string Breed { get; set; }

            public Dog()
                : base()
            {
                Console.Write("Окраска: ");
                this.Color = Console.ReadLine();

                Console.Write("Порода: ");
                this.Breed = Console.ReadLine();
            }


            public bool isBreed(string breed)
            {
                return breed == Breed;
            }

            public override string ToString()
            {
                return "Dog: [name: " + Name + ", birth year: " + BirthDate + ", color: " + Color + ", breed: " + Breed + "]";
            }
        }

        class Cat : Animal
        {

            public string Color { get; set; }
            public string Breed { get; set; }

            public Cat()
                : base()
            {
                Console.Write("Окраска: ");
                this.Color = Console.ReadLine();

                Console.Write("Порода: ");
                this.Breed = Console.ReadLine();
            }


            public bool isColor(string color)
            {
                return color == Color;
            }

            public void ChangeBreed(string breed, string conditionBreed)
            {
                if (conditionBreed == Breed) this.Breed = breed;
            }

            public override string ToString()
            {
                return "Cat: [name: " + Name + ", birth year: " + BirthDate + ", color: " + Color + ", breed: " + Breed + "]";
            }
        }
    }
}
