using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fiteryomin
{

    class Program
    {

        static void Main()
        {
            Garage garage = new Garage();
            Auto mercedes = new Auto("Mercedces");
            Auto audi = new Auto("Audi");
            Auto toyota = new Auto("Toyota");
            Auto porche = new Auto("Porche");

            garage.Add(mercedes);
            garage.Add(audi);
            garage.Add(toyota);
            garage.Add(porche);

            garage.WashAll(auto => Console.WriteLine("Моем " + auto.Name));
        }

    }

    public class Auto
    {
        public string Name { get; set; }
        public Auto(string name) {
            Name = name;
        }
    }

    public delegate void Wash(Auto auto);

    class Garage
    {
        public List<Auto> autos = new List<Auto>();
        public void Add(Auto auto) 
        {
            autos.Add(auto);
        }

        public void WashAll(Wash wash)
        {
            autos.ForEach((auto) => wash(auto));
        }
    }

    class Washer
    {
        public void Wash(Wash wash, Auto auto) 
        {
            wash(auto);
        }
    }


}

