using System;
using System.Collections.Generic;
using System.Text;

namespace АбстрактнаяфабрикаAbstract_Factory
{
    //определяет методы для создания объектов.
    //Причем методы возвращают абстрактные продукты, а не их конкретные реализации
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }


    //реализуют абстрактные методы базового класса и
    //непосредственно определяют какие конкретные продукты использовать
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }

    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    //определяют интерфейс для классов, объекты которых будут создаваться в программе.
    abstract class AbstractProductA { } 
    abstract class AbstractProductB { }


    //представляют конкретную реализацию абстрактных классов
    class ProductA1 : AbstractProductA { }
    class ProductA2 : AbstractProductA { }
    class ProductB1 : AbstractProductB { }
    class ProductB2 : AbstractProductB { }


    //использует класс фабрики для создания объектов.
    //При этом он использует исключительно абстрактный класс фабрики AbstractFactory
    //и абстрактные классы продуктов AbstractProductA и AbstractProductB
    //и никак не зависит от их конкретных реализаций
    class Client
    {
        private AbstractProductA abstractProductA;
        private AbstractProductB abstractProductB;

        public Client(AbstractFactory factory)
        {
            abstractProductA = factory.CreateProductA();
            abstractProductB = factory.CreateProductB();
        }

        public void Run() { }
    }
}
