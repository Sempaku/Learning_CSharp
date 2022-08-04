using System;

//________________________________________________________________________________|

// Существуют различные легковые машины,которые используют разные источники энергии:
// электричество, бензин, газ и так далее. Есть гибридные автомобили.
// В целом они похожи и отличаются преимущественно видом источника энергии.
// Не говоря уже о том, что мы можем изменить применяемый источник энергии,
// модифицировав автомобиль.
// И в данном случае вполне можно применить паттерн стратегию:


namespace Стратегия_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto = new Car(4, "BMW", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.WriteLine( );
        }
    }

    public interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине...");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве...");
        }
    }

    class Car
    {
        protected int passengers;
        protected string model;
        public IMovable Movable;

        public Car(int num, string mod, IMovable mov)
        {
            this.passengers = num;
            this.model = mod;
            Movable = mov;
        }
        public void Move()
        {
            Movable.Move();
        }
    }
}
