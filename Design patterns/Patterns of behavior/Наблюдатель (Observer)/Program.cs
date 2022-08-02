using System;
using System.Collections.Generic;

// Паттерн "Наблюдатель" (Observer) представляет поведенческий шаблон проектирования,
// который использует отношение "один ко многим". В этом отношении есть один
// наблюдаемый объект и множество наблюдателей. И при изменении наблюдаемого
// объекта автоматически происходит оповещение всех наблюдателей.

// Данный паттерн еще называют Publisher-Subscriber (издатель-подписчик), поскольку
// отношения издателя и подписчиков характеризуют действие данного паттерна:
// подписчики подписываются email-рассылку определенного сайта. Сайт-издатель с
// помощью email-рассылки уведомляет всех подписчиков о изменениях. А подписчики
// получают изменения и производят определенные действия: могут зайти на сайт,
// могут проигнорировать уведомления и т.д.

//__________________________________________________________________________________

// Когда использовать паттерн Наблюдатель?
// 1    Когда система состоит из множества классов, объекты которых должны
//      находиться в согласованных состояниях
// 2    Когда общая схема взаимодействия объектов предполагает две стороны:
//      одна рассылает сообщения и является главным, другая получает сообщения и
//      реагирует на них. Отделение логики обеих сторон позволяет их рассматривать
//      независимо и использовать отдельно друга от друга.
// 3    Когда существует один объект, рассылающий сообщения, и множество
//      подписчиков, которые получают сообщения. При этом точное число подписчиков
//      заранее неизвестно и процессе работы программы может изменяться.

//_________________________________________________________________________________

// Допустим, у нас есть биржа, где проходят торги, и есть брокеры и банки,
// которые следят за поступающей информацией и в зависимости от поступившей
// информации производят определенные действия

namespace Наблюдатель__Observer_
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("SBIR", stock);

            Broker broker = new Broker("Semyon", stock);

            // имитация торгов
            stock.Market();

            // брокер прекращает наблюдать за торгами
            broker.StopTrade();

            // имитация торгов
            stock.Market();

            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo sInfo;

        List<IObserver> observers;

        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(sInfo);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.EURO = rnd.Next(30, 50);
            NotifyObservers();
        }   
    }

    class StockInfo 
    {
        public int USD { get; set; }
        public int EURO { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;

        public Broker(string name , IObservable obs)
        {
            Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if(sInfo.USD > 30)
                Console.WriteLine($"Брокер {this.Name} продает доллары; Курс доллара: {sInfo.USD}");
            else
            {
                Console.WriteLine($"Брокер {this.Name} покупает доллары; Курс доллара: {sInfo.USD}");
            }
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable obs)
        {
            Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if(sInfo.EURO > 40)
                Console.WriteLine($"Банк {this.Name} продает евро. Курс евро: {sInfo.EURO}");
            else
                Console.WriteLine($"Банк {this.Name} покупает евро. Курс евро: {sInfo.EURO}");
        }

    }
}
