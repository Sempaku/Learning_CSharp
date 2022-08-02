using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Bridge_
{
    // Client: использует объекты Abstraction
    class Client
    {
        static void Run()
        {
            Abstraction abstraction;
            abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }

    // Abstraction: определяет базовый интерфейс и хранит ссылку на объект Implementor.
    // Выполнение операций в Abstraction делегируется методам объекта Implementor
    abstract class Abstraction
    {
        protected Implementor implementor;
        public Implementor Implementor
        {
            set { implementor = value; }
        }

        public Abstraction(Implementor imp)
        {
            implementor = imp;
        }

        public virtual void Operation()
        {
            implementor.OperationImp();
        }
    }

    // Implementor: определяет базовый интерфейс для конкретных реализаций.
    // Как правило, Implementor определяет только примитивные операции.
    // Более сложные операции, которые базируются на примитивных, определяются
    // в Abstraction
    abstract class Implementor
    {
        public abstract void OperationImp();
    }

    // RefinedAbstraction: уточненная абстракция, наследуется от Abstraction
    // и расширяет унаследованный интерфейс
    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp) : base(imp)
        {
            //
        }
        public override void Operation()
        {
            //
        }
    }

    // ConcreteImplementorA и ConcreteImplementorB: конкретные реализации,
    // которые унаследованы от Implementor
    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp()
        {
            //
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
            //
        }
    }
}
