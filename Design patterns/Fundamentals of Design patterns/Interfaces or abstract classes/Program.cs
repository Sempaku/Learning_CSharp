using System;

namespace Интерфейсы_или_абстрактные_классы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        
    }

    //Допустим, у нас есть система транспортных средств: легковой автомобиль, автобус,
    //трамвай, поезд и т.д. Поскольку данные объекты являются родственными, мы можем
    //выделить у них общие признаки, то в данном случае можно использовать абстрактные классы

    public abstract class Vehicle
    {
        public abstract void Move();
    }

    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Car move!!!");
        }
    }

    public class Bus : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Bus move!!!");
        }
    }

    public class Tram : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Tram move");
        }
    }


}
