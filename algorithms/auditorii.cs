using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiteryomin
{
    /*    
     * 1 класс - меню
     * при вызове объекта меню появляется следующее
     * - создание базы 
     * - добавление элемента в базу
     * - модификация элемента по номеру кабинета 
     * - выборка кабинетов с количеством посадочных мест >= заданного
     * - выборка кабинетов с проектором 
     * - выборка кабинетов с компьютерами и количеством мест...
     * - вывод всей информации базы
     * - выборка кабинетов на заданном этаже 
     * - выход из программы 
     * 
     * 2 класс - кабинет
     * - номер кабинета (первая цифра - номер этажа, две следующие - кабинет)
     * - количество посадочных мест
     * - наличие проектора (да/нет)
     * - наличие компьютеров (если компы есть, то кол-во мест = кол-во компьютеров)
     * 
     * предусмотреть после выполнения пункта мееню возврат в основное меню
     * предусмотреть проверку данных 
     * - если база незаполнена, то выборку сделать нельзя
     * - при модификации - продумать как происходит
     * - при вводе чисел - проверка чисел 
     * - номер кабинета <= 999 
     */

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MakeChoice();
        }
    }

    class Menu
    {
        List<Office> offices = new List<Office>();


        public void MakeChoice() {
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - добавить элемент в базу данных");
                Console.WriteLine("2 - модифицировать кабинет");
                Console.WriteLine("3 - выбрать кабинеты с заданным количеством мест");
                Console.WriteLine("4 - выбрать кабинеты с проектором");
                Console.WriteLine("5 - выбрать компьютерные классы с заданным количеством мест");
                Console.WriteLine("6 - вывести базу данных");
                Console.WriteLine("7 - выбрать кабинеты на заданном этаже");
                Console.WriteLine("8 - выйти из программы");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введите номер кабинета");
                            int number = int.Parse(Console.ReadLine());
                            if (offices.Any(of => of.number == number)) throw new Exception("Кабинет с таким номером уже существует");
                            
                            Console.WriteLine("Введите количество посадочных мест");
                            int places = int.Parse(Console.ReadLine());
                            if (places <= 0 || places >= 1000) throw new Exception("Неверный номер кабинета");

                            bool show = GetBool("Есть ли в кабинете проектор?");
                            bool computer = GetBool("Есть ли в кабинете компьютеры?");

                            offices.Add(new Office(number, places, show, computer));
                            Console.WriteLine("Кабинет создан!");
                            break;

                        case 2:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            Console.WriteLine("Введите номер кабинета");
                            number = int.Parse(Console.ReadLine());
                            var office = offices.Find(of => of.number == number);
                            if (office == null) throw new Exception("Кабинет не существует!");

                            Console.WriteLine("Введите количество посадочных мест: (по умолчанию " + office.places + ")");
                            string tryPlaces = Console.ReadLine();
                            if (int.TryParse(tryPlaces, out places))
                            {
                                office.places = places;
                            }

                            show = GetBoolOrDefault("Есть ли в кабинете проектор?", office.show);
                            computer = GetBoolOrDefault("Есть ли в кабинете компьютеры?", office.computer);
                            office.ChangeBools(show, computer);

                            Console.WriteLine("Кабинет модифицирован!");
                            break;

                        case 3:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            Console.WriteLine("Введите необходимое количество мест: ");
                            places = int.Parse(Console.ReadLine());
                            foreach (var of in offices.FindAll(of => of.places >= places))
                                Console.WriteLine(of);

                            break;
                        case 4:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            foreach (var of in offices.FindAll(of => of.show))
                                Console.WriteLine(of);
                            break;

                        case 5:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            Console.WriteLine("Введите необходимое количество мест: ");
                            places = int.Parse(Console.ReadLine());
                            foreach (var of in offices.FindAll(of => of.places >= places && of.computer))
                                Console.WriteLine(of);

                            break;

                        case 6:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            foreach (var of in offices)
                                Console.WriteLine(of);
                            break;
                        case 7:
                            if (!offices.Any()) throw new Exception("База данных еще не заполнена");
                            Console.WriteLine("Введите необходимый этаж: ");
                            int floor = int.Parse(Console.ReadLine());
                            foreach (var of in offices.FindAll(of => of.number / 100 == floor))
                                Console.WriteLine(of);

                            break;
                        case 8:
                            return;

                        default:
                            throw new Exception("Недопустимый пункт меню");
                    }
                    

                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        bool GetBool(string message)
        {
            while (true)
            {
                Console.WriteLine(message + " y/n");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                    return true;
                else if (input.ToLower() == "n")
                    return false;
                else
                    Console.WriteLine("Данные нераспознаны");
            }
        }

        bool GetBoolOrDefault(string message, bool defaultValue)
        {
            Console.WriteLine(message + " y/n (по умолчанию: "+ (defaultValue ? "y": "n") +")");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
                return true;
            else if (input.ToLower() == "n")
                return false;
            else
            {
                Console.WriteLine("Данные нераспознаны");
                Console.WriteLine("Использовано значение по умолчанию");
                return defaultValue;
            }
                
        }
    }


    class Office {
        public int number {get; set;}
        public int places { get; set; }
        public bool show { get; set; }
        public bool computer { get; set; }


        public Office(int number, int places, bool show, bool computer) {
            if (number <= 100 || number >= 999) throw new Exception("Недопустимый номер кабинета");
            if (places <= 0) throw new Exception("Недопустимое количество посадочных мест");

            this.number = number;
            this.places = places;
            this.show = show;
            this.computer = computer;
        }

        public void ChangeBools(bool show, bool computer)
        {
            this.show = show;
            this.computer = computer;
        }

        public override string ToString()
        {
            return string.Format("Кабинет №{0} - мест: {1}, проектор: {2}, компьютеры: {3}", this.number, this.places, this.show ? "есть" : "нет", this.computer ? "есть" : "нет");
        }
    }
}
