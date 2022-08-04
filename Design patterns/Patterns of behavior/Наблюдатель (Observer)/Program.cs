using System;
using System.Collections.Generic;
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
