using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Состояние__State_
{
    class Programy
    {
        static void Mainy()
        {
            Context context = new Context(new StateA()); // context = state a
            context.Request(); // context = state b
            context.Request(); // context = state a
        }
    }

    // State: определяет интерфейс состояния
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    // Классы StateA и StateB - конкретные реализации состояний
    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    // Context: представляет объект, поведение которого должно динамически
    // изменяться в соответствии с состоянием.
    // Выполнение же конкретных действий делегируется объекту состояния
    class Context
    {
        public State State { get; set; }
        public Context(State state)
        {
            this.State = state;
        }

        public void Request()
        {
            this.State.Handle(this);
        }
    }
}
