using System;
// ________________________________________________________________________________

// Допустим, у нас есть путешественник, который путешествует на машине.
// Но в какой-то момент ему приходится передвигаться по пескам пустыни,
// где он не может ехать на машине.
// Зато он может использовать для передвижения верблюда.
// Однако в классе путешественника использование класса верблюда не предусмотрено,
// поэтому нам надо использовать адаптер:

namespace Адаптер__Adapter_
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            Auto auto = new Auto();
            driver.Travel(auto);
            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);
        }
    }

    interface ITransport
    {
        void Drive();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дорогу");
        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд мдет по пескам пустыни");
        }
    }

    //Adapter от транспорта к верблюду
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel camel)
        {
            this.camel = camel;
        }

        public void Drive()
        {
            camel.Move();
        }
    }

}
