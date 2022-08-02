using System;


// Паттерн Посредник (Mediator) представляет такой шаблон проектирования,
// который обеспечивает взаимодействие множества объектов без необходимости
// ссылаться друг на друга. Тем самым достигается слабосвязанность взаимодействующих
// объектов.

// Когда используется паттерн Посредник?
// 1 Когда имеется множество взаимосвязаных объектов, связи между которыми сложны
// и запутаны.
// 2 Когда необходимо повторно использовать объект, однако повторное использование
// затруднено в силу сильных связей с другими объектами.

// _________________________________________________________________________________

// Рассмотрим реальный пример. Система создания программных продуктов включает ряд
// акторов: заказчики, программисты, тестировщики и так далее. Но нередко все эти
// акторы взаимодействуют между собой не непосредственно, а опосредованно через
// менеджера проектов. То есть менеджер проектов выполняет роль посредника.
// В этом случае процесс взаимодействия между объектами мы могли бы описать так

namespace Посредник__Mediator_
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = (CustomerColleague)customer;
            mediator.Programmer = (ProgrammerColleague)programmer;
            mediator.Tester = (TesterColleague)tester;

            customer.Send("Create app for me");
            programmer.Send("App is gone!");
            tester.Send("App apply all tests");


        }
    }

    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    abstract class Colleague
    {
        protected Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }

    // class заказчика
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator)
        {
            //
        }
        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: {0}", message);
        }
    }

    // class программиста

    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator)
        {
            //
        }
        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: {0}", message);
        }
    }

    // class тестера
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator)
        {
            //
        }
        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестировщику: {0}", message);
        }
    }

    class ManagerMediator : Mediator
    {
        public CustomerColleague Customer { get; set; }
        public ProgrammerColleague Programmer { get; set; }
        public TesterColleague Tester { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            if (Customer == colleague)
                Programmer.Notify(msg);
            else if (Programmer == colleague)
                Tester.Notify(msg);
            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }
}
