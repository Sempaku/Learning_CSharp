using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Decorator_
{
    // Component: абстрактный класс, который определяет интерфейс для наследуемых
    // объектов
    abstract class Component
    {
        public abstract void Operation();
    }

    // ConcreteComponent: конкретная реализация компонента, в которую с помощью
    // декоратора добавляется новая функциональность
    class ConcreteComponent : Component
    {
        public override void Operation()
        { }
    }

    // Decorator: собственно декоратор, реализуется в виде абстрактного класса и
    // имеет тот же базовый класс, что и декорируемые объекты.
    // Поэтому базовый класс Component должен быть по возможности легким и
    // определять только базовый интерфейс.
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
                component.Operation();
        }

    }

    // Классы ConcreteDecoratorA и ConcreteDecoratorB представляют дополнительные
    // функциональности, которыми должен быть расширен объект ConcreteComponent.
    class ConcreteDecorator1 : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }

    class ConcreteDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
}
