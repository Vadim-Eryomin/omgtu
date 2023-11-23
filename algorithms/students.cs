using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
        /*
         * опишем класс студент
         * фио, год рождения, наименование группы
         * конструкторы, свойства,
         * в головной программе массив экземпляров
         * в классе написать два метода, которые выводят
         * на экран поля экземпляра
         * если поле совпадает с годом рождения
         * если поле совпадает с группой
         * 
         * поиск по году рождения
         * поиск по группе
         */

        static void Main()
        {
            ArrayList students = new ArrayList();
            String input;
            do {
                Console.Write("Введите имя: ");
                String name = Console.ReadLine();

                Console.Write("Введите год рождения: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Введите группу: ");
                String group = Console.ReadLine();

                students.Add(new Student(name, year, group));

                Console.Write("Создать еще одного? д/н ");
                input = Console.ReadLine();
            } while(input == "д");

            do {
                Console.Write("Поиск по году? д/(н - по группе)");
                input = Console.ReadLine();
                if (input == "д") 
                {
                    Console.Write("Введите год: ");
                    int year = int.Parse(Console.ReadLine());
                    for (int i = 0; i < students.ToArray().Length; i++)
                        ((Student) students[i]).ShowIfYear(year);
                }
                else
                {
                    Console.Write("Введите групу: ");
                    String group = Console.ReadLine();
                    for (int i = 0; i < students.ToArray().Length; i++)
                        ((Student) students[i]).ShowIfGroup(group);
                }

                Console.Write("Еще ищем? д/н ");
                input = Console.ReadLine();
            } while(input == "д");
            Console.ReadKey();
        }
    }

    class Student
    {
        public String Fio { get; set; }
        public int BirthYear { get; set; }        
        public String Group { get; set; }

        public Student(): this("Аноним") {
            
        }

        public Student(String fio): this(fio, 2000) { 
        
        }

        public Student(String fio, int year): this(fio, year, "Undefined") { 
        
        }

        public Student(String fio, int birthYear, String group) 
        {
            Group = group;
            Fio = fio;
            BirthYear = birthYear;
        }

        public void ShowIfYear(int year) 
        {
            if (BirthYear == year) 
            {
                Console.WriteLine(ToString());
            }
        }

        public void ShowIfGroup(String group) 
        {
            if (Group == group)
            {
                Console.WriteLine(ToString());
            }
        }

        public String ToString() 
        {
            return "Студент " + Fio + ", " + BirthYear + "г., " + "Группа: " + Group;
        }
    }
}
