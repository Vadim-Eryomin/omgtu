using System;
using System.Linq;
using System.Collections;

namespace ConsoleApplication5
{

    class Program
    {
        /**
         * склад =>
         * массив из элементов
         *      дата поставки 
         *      дата изготовления 
         *      количество товара
         *      стоимость
         * массив из элементов
         *      дата продажи 
         *      количество проданных 
         * наименование товара
         * срок годности в днях
         * 
         * выборки =>
         *      по остаткам годного товара
         *      по остаткам на списание
         *      по общей сумме продаж (какой товар на какую сумму)
         *      
         * дата = день и месяц
         * в месяце тридцать дней
         */

        /**
         * две доставки, между ними больше срока годности
         * попытаться продать, когда его нет
         */
        static void Main()
        {
            Product milk = new Product();
            milk.Bought = new ArrayList(new BuyInstance[] {
                new BuyInstance(new MyDate(1, 1), new MyDate(1, 1), 50, 10.0f),
                new BuyInstance(new MyDate(10, 1), new MyDate(9, 1), 50, 10.0f),
            });
            milk.Sold = new ArrayList(new SoldInstance[] {
                new SoldInstance(new MyDate(1, 1), 40),
                new SoldInstance(new MyDate(6, 1), 50),
            });
            milk.Name = "Молоко";
            milk.ExpiresDays = 4;

            ArrayList buySold;
            ArrayList expires;
            milk.Serialize(out buySold, out expires);

            int buySoldIndex = 0;
            int expireIndex = 0;

            int bought = 0;
            int sold = 0;
            int expired = 0;

            int i = 0;

            while (i++ < 10)
            {
                Event buySoldInstance = buySoldIndex == buySold.Capacity ? null : buySold[buySoldIndex] as Event;
                Event expireInstance = expireIndex == expires.Capacity ? null : expires[expireIndex] as Event;

                if (buySoldInstance == null && expireInstance == null) break;

                Console.WriteLine(bought + " " + sold + " " + expired);

                if (buySoldInstance != null && buySoldInstance.DateOfEvent.IsBefore(expireInstance.DateOfEvent)) {
                    
                    buySoldIndex++;
                    if (buySoldInstance.Type == "bought")
                    {
                        
                        bought += buySoldInstance.Count;
                    }
                    if (buySoldInstance.Type == "sold")
                    {
                        if (bought - expired < sold + buySoldInstance.Count)
                        {
                            Console.WriteLine("Где-то косяк!");
                            Console.WriteLine("В " + buySoldInstance.DateOfEvent.ToString() + " могу продать только " + (buySoldInstance.Count - bought - expired) + " шт!");
                            sold += bought - expired;
                        }
                        else
                        {
                            sold += buySoldInstance.Count;
                        }
                    }
                }
                else
                {
                    expireIndex++;
                    expired += expireInstance.Count - sold;
                    sold = 0;
                }
            }

            Console.ReadKey();
        }



        class Product {
            public ArrayList Bought { get; set; }
            public ArrayList Sold { get; set; }
            public string Name { get; set; }
            public int ExpiresDays { get; set; }

            public int ChooseNonExpired(MyDate today) 
            {
                int number = 0;


                return number;
            }

            public void Serialize(out ArrayList buySold, out ArrayList expires) 
            {
                ArrayList buySoldEvents = new ArrayList();
                ArrayList expiresEvents = new ArrayList();

                int indexOfBought = 0;
                int indexOfSold = 0;

                while (true)
                {
                    if (indexOfBought == Bought.Capacity && indexOfSold == Sold.Capacity)
                    {
                        buySold = buySoldEvents;
                        expires = expiresEvents;
                        return;
                    }
                    else if (indexOfBought == Bought.Capacity)
                    {
                        var soldEvent = this.Sold[indexOfSold++] as SoldInstance;
                        buySoldEvents.Add(new Event(soldEvent.SoldDate, soldEvent.Quantity, "sold"));

                        // вычесть из первого ненулевого expire ивента, который позже, чем sold

                     }
                    else if (indexOfSold == Sold.Capacity)
                    {
                        var boughtEvent = this.Bought[indexOfBought++] as BuyInstance;
                        buySoldEvents.Add(new Event(boughtEvent.DeliverDate, boughtEvent.Quantity, "bought"));
                        expiresEvents.Add(new Event(boughtEvent.MadeDate.AfterDays(ExpiresDays), boughtEvent.Quantity, "expire"));
                    }
                    else
                    {
                        var soldEvent = this.Sold[indexOfSold] as SoldInstance;
                        var boughtEvent = this.Bought[indexOfBought] as BuyInstance;

                        if (soldEvent.SoldDate.IsBefore(boughtEvent.DeliverDate))
                        {
                            indexOfSold++;
                            buySoldEvents.Add(new Event(soldEvent.SoldDate, soldEvent.Quantity, "sold"));
                        }
                        else
                        {
                            indexOfBought++;
                            buySoldEvents.Add(new Event(boughtEvent.DeliverDate, boughtEvent.Quantity, "bought"));
                            expiresEvents.Add(new Event(boughtEvent.MadeDate.AfterDays(ExpiresDays), boughtEvent.Quantity, "expire"));
                        }
                    }
                }
            }
        }

        class Event
        {
            public MyDate DateOfEvent { get; set; }
            public int Count { get; set; }
            public string Type { get; set; }

            public Event(MyDate date, int count, string type)
            {
                DateOfEvent = date;
                Count = count;
                Type = type;
            }

            public override string ToString()
            {
                return "Event: " + DateOfEvent.ToString() + ", count: " + Count + ", type: " + Type;
            }
        }

        class BuyInstance {
            public MyDate DeliverDate { get; set; }
            public MyDate MadeDate { get; set; }

            public int Quantity { get; set; }
            public float Cost { get; set; }

            public bool IsExpired(int ExpiresInDays, MyDate today) 
            {
                return MadeDate.Month * 30 + MadeDate.Day + ExpiresInDays < today.Month * 30 + today.Day;
            }

            public BuyInstance()
            {

            }

            public BuyInstance(MyDate deliverDate, MyDate madeDate, int quantity, float cost) 
            {
                DeliverDate = deliverDate;
                MadeDate = madeDate;
                Quantity = quantity;
                Cost = cost;
            }
        }

        class SoldInstance
        {
            public MyDate SoldDate { get; set; }
            public int Quantity { get; set; }

            public SoldInstance(MyDate soldDate, int quantity)
            {
                SoldDate = soldDate;
                Quantity = quantity;
            }
        }

        class MyDate {
            public int Day { get; set; }
            public int Month { get; set; }

            public bool IsBefore(MyDate than) // this is earlier than "than" date
            {
                return this.Month * 30 + this.Day < than.Month * 30 + than.Day;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is MyDate)) return false;

                var obj1 = obj as MyDate;

                return (this.Day == obj1.Day && this.Month == obj1.Month);
            }

            public MyDate() 
            {
            
            }

            public MyDate(int day, int month)
            {
                Day = day;
                Month = month;
            }

            public MyDate AfterDays(int days)
            {
                return new MyDate((Day + days) % 30, Month + (days / 30));
            }

            public MyDate BeforeDays(int days)
            {
                return new MyDate((Day + 360 - days) % 30, Month + (days / 30) - Day < days % 30 ? 1 : 0);
            }

            public override string ToString()
            {
                return "Date: (d: " + Day + ", m: " + Month + ")";
            }
        }

        public static float GetFloat(string prompt)
        {
            Console.Write(prompt);
            return float.Parse(Console.ReadLine());
        }

    }

}

