using System;
using System.Collections.Generic;
using System.Text;

namespace Фабричный_метод_Factory_Method_
{

    abstract class Product { }

    class ConcreteProductA : Product { }
    class ConcreteProductB : Product { }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
