using System;

// Цепочка Обязанностей (Chain of responsibility) - поведенческий шаблон
// проектирования, который позволяет избежать жесткой привязки отправителя запроса
// к получателю. Все возможные обработчики запроса образуют цепочку, а сам запрос
// перемещается по этой цепочке. Каждый объект в этой цепочке при получении запроса
// выбирает, либо закончить обработку запроса, либо передать запрос на обработку
// следующему по цепочке объекту.

// Когда применяется цепочка обязанностей?
// 1 Когда имеется более одного объекта, который может обработать определенный запрос
// 2 Когда надо передать запрос на выполнение одному из нескольких объект,
// точно не определяя, какому именно объекту
// 3 Когда набор объектов задается динамически

//________________________________________________________________________________

// Использование цепочки обязанностей дает нам следующие преимущества:
// 1 Ослабление связанности между объектами. Отправителю и получателю запроса
// ничего не известно друг о друге. Клиенту неизветна цепочка объектов, какие
// именно объекты составляют ее, как запрос в ней передается.
// 2 В цепочку с легкостью можно добавлять новые типы объектов,
// которые реализуют общий интерфейс.

//__________________________________________________________________________________

// Рассмотрим конкретный пример.
// Допустим, необходимо послать человеку определенную сумму денег.
// Однако мы точно не знаем, какой способ отправки может использоваться:
// банковский перевод, системы перевода типа WesternUnion и Unistream или
// система онлайн-платежей PayPal. Нам просто надо внести сумму, выбрать человека
// и нажать на кнопку. Подобная система может использоваться на сайтах фриланса,
// где все отношения между исполнителями и заказчиками происходят опосредованно
// через функции системы и где не надо знать точные данные получателя.

namespace Цепочка_Обязанностей_Chain_of_responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Receiver receiver = new Receiver(false, true,false);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();

            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHandler;

            bankPaymentHandler.Handle(receiver);
        }
    }

    class Receiver
    {
        public bool BankTransfer { get; set; }
        public bool MoneyTransfer { get; set; }
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }
    class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer is true)
                Console.WriteLine("--> BANK TRANSFER");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer is true)
                Console.WriteLine("--> PAYPAL TRANSFER");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }

    class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer is true)
                Console.WriteLine("--> MONEY TRANSFER");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
}
