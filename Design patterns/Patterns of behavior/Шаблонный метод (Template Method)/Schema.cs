using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Template_Method_
{
    // AbstractClass: определяет шаблонный метод TemplateMethod(),
    // который реализует алгоритм. Алгоритм может состоять из последовательности
    // вызовов других методов, часть из которых может быть абстрактными и должны
    // быть переопределены в классах-наследниках.
    // При этом сам метод TemplateMethod(), представляющий структуру алгоритма,
    // переопределяться не должен.
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }
        public abstract void Operation1();
        public abstract void Operation2();
    }

    // ConcreteClass: подкласс, который может переопределять различные
    // методы родительского класса.
    class ConcreteClass : AbstractClass
    {
        public override void Operation1()
        {
            //
        }
        public override void Operation2()
        {
            //
        }

    }

}
