using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eryominfit
{
    class Program
    {
        class Count 
        {
            public int Number { get; set; }
            public string Fio { get; set; }
            public double Income { get; set; }
            public double Expenses { get; set; }
            public double Tax { get { return Income / 20; } }

            public Count(int number, string fio, double income, double expense) {
                Number = number;
                Fio = fio;
                Income = income;
                Expenses = expense;
            }

            public override string ToString()
            {
                return Number + ", " + Fio + ": Доход = " + Income + ", расход = " + Expenses + ", налог = " + Tax;
            }
        }

        static void Main() 
        { 
            Count[] data = new Count[] {
                new Count(4354534, "Пупкин Василий Михайлович", 50, 70),
                new Count(1434121, "Пупкин Василий Михайлович", 6, 82),
                new Count(4357357, "Пупкин Василий Михайлович", 19, 7),
                new Count(4534359, "Пупкин Василий Михайлович", 35, 12),
                new Count(8797878, "Пупкин Василий Михайлович", 35, 19),
                new Count(2314544, "Пупкин Василий Михайлович", 16, 35),
                new Count(4687544, "Пупкин Василий Михайлович", 83, 80),
                new Count(4539734, "Пупкин Василий Михайлович", 83, 5)
            };


            Console.WriteLine("Отрицательный баланс");
            data
                .Where(e => e.Income - e.Expenses - e.Tax < 0)
                .ToList()
                .ForEach(e => Console.WriteLine(e));


            Console.WriteLine("Количество клиентов с положительным балансом: " +
                data.Where(e => e.Income - e.Expenses - e.Tax > 0).Count());


            double maxIncome = data.Max(e => e.Income);
            Console.WriteLine("Клиенты с максимальным доходом: ");
            data
                .Where(e => e.Income == maxIncome)
                .ToList()
                .ForEach(e => Console.WriteLine(e));


            Console.WriteLine("Общая сумма налогов составила: " + data.Sum(e => e.Tax));
        }
    }
}

