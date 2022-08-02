using System;
using System.Collections.Generic;
using System.Text;

namespace Прототип__Prototype_
{
    // создает объекты прототипов с помощью метода Clone()
    class Client
    {
        void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();
        }
    }

    // определяет интерфейс для клонирования самого себя, который, как правило,
    // представляет метод Clone()
    abstract class Prototype
    {
        public int Id { get; set; }
        public Prototype(int id)
        {
            this.Id = id;
        }
        public abstract Prototype Clone();
    }

    // конкретные реализации прототипа. Реализуют метод Clone()
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id) { }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }
    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id) { }
        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }
}
