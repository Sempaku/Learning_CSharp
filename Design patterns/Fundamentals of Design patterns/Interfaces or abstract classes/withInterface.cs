using System;
using System.Collections.Generic;
using System.Text;

//предположим, что наша система транспорта не ограничивается вышеперечисленными транспортными
//средствами. Например, мы можем добавить самолеты, лодки.
//Возможно, также мы добавим лошадь - животное, которое может также выполнять роль
//транспортного средства. Также можно добавить дирижабль. Вобщем получается довольно
//широкий круг объектов, которые связаны только тем, что являются транспортным средством
//и должны реализовать некоторый метод Move(), выполняющий перемещение.

//Так как объекты малосвязанные между собой, то для определения общего для всех них
//функционала лучше определить интерфейс. Тем более некоторые из этих объектов могут
//существовать в рамках параллельных систем классификаций. Например, лошадь может быть
//классом в структуре системы классов животного мира.


namespace Интерфейсы_или_абстрактные_классы
{    
    public interface IMovable
    {
        void Move();
    }

    public abstract class Vehicle2 : IMovable
    {
        public abstract void Move();
    }

    public class Car2 : Vehicle2
    {
        public override void Move()
        {
            Console.WriteLine("Car2 move");
        }
    }

    public class Bus2 : Vehicle2
    {
        public override void Move()
        {
            Console.WriteLine("Bus2 move");
        }
    }

    public class Horse : IMovable
    {
        public void Move() => Console.WriteLine("Horse drive)");

    }

    public class Airbus : IMovable
    {
        public void Move() => Console.WriteLine("Airbus fly");
    }

}
