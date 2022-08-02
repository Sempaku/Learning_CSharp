using System;
using System.Collections.Generic;
using System.Text;

// То есть клиент ничего не знает об Adaptee, он знает и использует только объекты
// Target. И благодаря адаптеру мы можем на клиенте использовать объекты Adaptee
// как Target


namespace Schema_Adapter_
{
    // Client: использует объекты Target для реализации своих задач 
    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }

    // Target: представляет объекты, которые используются клиентом
    class Target
    {
        public virtual void Request()
        {

        }
    }

    // Adapter: собственно адаптер, который позволяет работать с объектами Adaptee
    // как с объектами Target.
    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    // Adaptee: представляет адаптируемый класс, который мы хотели бы использовать
    // у клиента вместо объектов Target
    class Adaptee
    {
        public void SpecificRequest() { }
    }
}
