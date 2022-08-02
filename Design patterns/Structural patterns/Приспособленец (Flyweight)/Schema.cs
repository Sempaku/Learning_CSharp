using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Schema_Flyweight_
{
    // FlyweightFactory: фабрика приспособленцев - создает объекты разделяемых
    // приспособленцев. Так как приспособленцы разделяются, то клиент не должен
    // создавать их напрямую. Все созданные объекты хранятся в пуле.
    // В примере выше для определения пула используется объект Hashtable,
    // но это не обязательно. Можно применять и другие классы коллекций.
    // Однако в зависимости от сложности структуры, хранящей разделяемые объекты,
    // особенно если у нас большое количество приспособленцев, то может
    // увеличиваться время на поиск нужного приспособленца - наверное это один из
    // немногих недостатков данного паттерна.
    class FlyweightFactory
    {
        Hashtable flyweight = new Hashtable();
        public FlyweightFactory()
        {
            flyweight.Add("X", new ConcreteFlyweight());
            flyweight.Add("Y", new ConcreteFlyweight());
            flyweight.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!flyweight.ContainsKey(key))
                flyweight.Add(key, new ConcreteFlyweight());
            return flyweight[key] as Flyweight;
        }
    }

    // Flyweight: определяет интерфейс, через который приспособленцы-разделяемые
    // объекты могут получать внешнее состояние или воздействовать на него
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }

    // ConcreteFlyweight: конкретный класс разделяемого приспособленца.
    // Реализует интерфейс, объявленный в типе Flyweight, и при необходимости
    // добавляет внутреннее состояние. Причем любое сохраняемое им состояние должно
    // быть внутренним, не зависящим от контекста
    class ConcreteFlyweight : Flyweight
    {
        int intrinsicState;
        public override void Operation(int extrinsicState)
        {
            //
        }
    }

    // UnsharedConcreteFlyweight: еще одна конкретная реализация интерфейса,
    // определенного в типе Flyweight, только теперь объекты этого класса являются
    // неразделяемыми
    class UnsharedConcreteFlyweight : Flyweight
    {
        int allState;
        public override void Operation(int extrinsicState)
        {
            allState = extrinsicState;
        }
    }

    // Client: использует объекты приспособленцев. Может хранить внешнее состояние
    // и передавать его в качестве аргументов в методы приспособленцев
    class Client
    {
        static void Run()
        {
            int extensicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extensicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extensicstate);

            Flyweight fd = f.GetFlyweight("D");
            fd.Operation(--extensicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

            uf.Operation(--extensicstate);
        }
    }
}
