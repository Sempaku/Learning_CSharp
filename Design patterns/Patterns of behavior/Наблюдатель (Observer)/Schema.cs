/*using System;
using System.Collections.Generic;
using System.Text;

namespace Наблюдатель__Observer_
{
    // IObservable представляет наблюдаемый объект. Определяет три метода:
    // AddObserver() (для добавления наблюдателя),
    // RemoveObserver() (удаление набюдателя)
    // NotifyObservers() (уведомление наблюдателей)

    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    // IObserver представляет наблюдателя, который подписывается на все уведомления
    // наблюдаемого объекта. Определяет метод Update(), который вызывается
    // наблюдаемым объектом для уведомления наблюдателя.
    interface IObserver
    {
        void Update();
    }

    // Kонкретная реализация интерфейса IObservable.
    // Определяет коллекцию объектов наблюдателей
    class ConcreteObservable : IObservable
    {
        private List<IObserver> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Update();
        }
    }

    // Kонкретная реализация интерфейса IObserver
    class ConcreteObserver : IObserver
    {
        public void Update() { }
    }
}
*/