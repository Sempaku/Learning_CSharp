using System;

namespace Отношения_между_классами_и_объектами
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //Наследование
    //Наследование определяет отношение IS A, то есть "является".
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Manager : User
    {
        public string Compaby { get; set; }
    }

    //_____________________________________________________________

    // Реализация

    // Реализация предполагает определение интерфейса и его реализация в классах.
    // Например, имеется интерфейс IMovable с методом Move, который реализуется в классе Car

    public interface IMovable
    {
        void Move();
    }
    public class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Move...");
        }
    }

    //______________________________________________________________________________

    // Ассоциация

    // Ассоциация - это отношение, при котором объекты одного типа неким образом
    // связаны с объектами другого типа.
    // Например, объект одного типа содержит или использует объект другого типа

    class Team { }

    class Player
    {
        public Team Team { get; set; }
    }

    //___________________________________________________________________________________

    // Композиция
    // Композиция определяет отношение HAS A, то есть отношение "имеет".
    // Например, в класс автомобиля содержит объект класса электрического двигателя

    public class ElectricEngine { }

    public class ElectroCar
    {
        ElectricEngine engine;
        public ElectroCar()
        {
            engine = new ElectricEngine();
        }
    }

    // Агрегация
    // От композиции следует отличать агрегацию.
    // Она также предполагает отношение HAS A, но реализуется она иначе

    public abstract class Engine { }

    public class Car2
    {
        Engine engine;
        public Car2(Engine eng)
        {
            engine = eng;
        }
    }


}
