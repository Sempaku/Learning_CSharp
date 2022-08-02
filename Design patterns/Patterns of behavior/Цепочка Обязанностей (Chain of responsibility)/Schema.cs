using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Chain_of_responsibility
{
    // Client: отправляет запрос объекту Handler
    class Client
    {
        void Main()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            h1.HandlerRequest(2);
        }
    }

    // Handler: определяет интерфейс для обработки запроса.
    // Также может определять ссылку на следующий обработчик запроса
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandlerRequest(int condition);
    }

    // ConcreteHandler1 и ConcreteHandler2: конкретные обработчики,
    // которые реализуют функционал для обработки запроса.
    // При невозможности обработки и наличия ссылки на следующий обработчик,
    // передают запрос этому обработчику

    // В данном случае для простоты примера в качестве параметра передается
    // некоторое число, сначала обработчик обрабатывает запрос и, если передано
    // соответствующее число, завершает его обработку. Иначе передает запрос на
    // обработку следующем в цепи обработчику при его наличии.
    class ConcreteHandler1 : Handler
    {
        public override void HandlerRequest(int condition)
        {
            // некоторая обработка запроса
            //.............................

            if (condition == 1)
            {
                // завершение выполнение запроса
            }
            // передача запроса дальше по цепочке при наличии в ней обработчиков
            else if (Successor != null)
                Successor.HandlerRequest(condition);

        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void HandlerRequest(int condition)
        {
            if (condition == 2)
            {
                // завершение обработки запроса
            }
            // передача запроса по цепи
            else if (Successor != null)
            {
                Successor.HandlerRequest(condition);
            }
        }
    }

}
