using System;

// Декоратор (Decorator) представляет структурный шаблон проектирования,
// который позволяет динамически подключать к объекту дополнительную
// функциональность.

// Для определения нового функционала в классах нередко используется наследование.
// Декораторы же предоставляет наследованию более гибкую альтернативу, поскольку
// позволяют динамически в процессе выполнения определять новые возможности у
// объектов.
//_________________________________________________________________________________

// Когда следует использовать декораторы?
//   1 Когда надо динамически добавлять к объекту новые функциональные возможности.
// При этом данные возможности могут быть сняты с объекта
//   2 Когда применение наследования неприемлемо.
// Например, если нам надо определить множество различных функциональностей и для
// каждой функциональности наследовать отдельный класс, то структура классов может
// очень сильно разрастись. Еще больше она может разрастись, если нам необходимо
// создать классы, реализующие все возможные сочетания добавляемых функциональностей.
//__________________________________________________________________________________

// Рассмотрим пример.
// Допустим, у нас есть пиццерия, которая готовит различные типы пицц с различными
// добавками. Есть итальянская, болгарская пиццы.
// К ним могут добавляться помидоры, сыр и т.д.
// И в зависимости от типа пицц и комбинаций добавок пицца может иметь разную
// стоимость.

namespace Декоратор__Decorator_
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1);
            Console.WriteLine("Label:{0}   Cost{1}",pizza1.Name,pizza1.GetCost());

            Pizza pizza2 = new BulgerianPizza();
            pizza2 = new CheesePizza(pizza2);
            Console.WriteLine("Label:{0}   Cost{1}", pizza2.Name, pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new CheesePizza(pizza3);
            pizza3 = new TomatoPizza(pizza3);
            Console.WriteLine("Label:{0}   Cost{1}", pizza3.Name, pizza3.GetCost());
        }
    }

    abstract class Pizza
    {
        public string Name { get; protected set; }
        public Pizza(string n)
        {
            this.Name = n;
        }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }

        public override int GetCost()
        {
            return 10;
        }
    }

    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p  ) : base(p.Name + " с томатами",p)
        {

        }
        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + " с сыром",p)
        {

        }
        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}
