using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Schema_Iterator_
{
    // Client: использует объект Aggregate и итератор для его обхода
    class Client
    {
        public void Main()
        {
            Aggregate a = new ConcreteAgregate();

            Iterator i = a.CreateIterator();

            object item = i.First();
            while (!i.IsDone())
            {
                item = i.Next();
            }
        }
    }

    // Aggregate: определяет интерфейс для создания объекта-итератора
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract object this[int index] { get; set; }
    }

    
    // ConcreteAggregate: конкретная реализация Aggregate.
    // Хранит элементы, которые надо будет перебирать
    class ConcreteAgregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    // Iterator: определяет интерфейс для обхода составных объектов
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    // ConcreteIterator: конкретная реализация итератора для обхода
    // объекта Aggregate. Для фиксации индекса текущего перебираемого
    // элемента использует целочисленную переменную _current    
    class ConcreteIterator :  Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate a)
        {
            _aggregate = a;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            _current++;
            if (_current < _aggregate.Count)
                ret = _aggregate[_current];
            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            if (_current >= _aggregate.Count)
                return true;
            return false;
        }
    }
}
