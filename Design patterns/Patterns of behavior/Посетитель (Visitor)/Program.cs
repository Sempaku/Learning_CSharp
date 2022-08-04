using System;
using System.Collections.Generic;

//________________________________________________________________________________

// Рассмотрим на примере. Как известно, нередко для разных категорий вкладчиков
// банки имеют свои правила: оформления вкладов, выдача кредитов, начисления
// процентов и т.д. Соответственно классы, описывающие данные объекты, тоже будут
// разными. Но что важно, как правило, правила обслуживания четко описает весь
// набор категорий клиентов. Например, есть физические лица, есть юридические,
// отдельные правила для индивидуальных или частных предпринимателей и т.д.
// Поэтому структура классов, представляющая клиентов будет относительно
// фиксированной, то есть не склонной к изменениям.

// И допустим, в какой-то момент мы решили добавить в классы клиентов функционал
// сериализации в html. В этом случае мы могли бы построить следующую структуру
// классов:


namespace Посетитель__Visitor_
{
    class Program
    {
        static void Main(string[] args)
        {
            var structure = new Bank();
            structure.Add(new Person { Name = "Semyon Tsyganov", Number = "1337" });
            structure.Add(new Company { Name = "SBIR", Number = "1433", RegNumber = "123123" });
            structure.Accept(new XmlVisitor());
            structure.Accept(new HtmlVisitor());
        }
    }

    interface IVisitor
    {
        void VisitPersonAcc(Person acc);
        void VisitCompanyAcc(Company acc);
    }

    // сериализатор в html
    class HtmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
        public void VisitCompanyAcc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }

    // сериализатор xml
    class XmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<Person><Name>" + acc.Name + "</Name>" +
                "<Number>" + acc.Number + "</Number><Person>";
            Console.WriteLine(result);
        }

        public void VisitCompanyAcc(Company acc)
        {
            string result = "<Company><Name>" + acc.Name + "</Name>" +
                "<RegNumber>" + acc.RegNumber + "</RegNumber>" +
                "<Number>" + acc.Number + "</Number><Company>";
            Console.WriteLine(result);
        }
    }

    class Bank
    {
        List<IAccount> accounts = new List<IAccount>();
        public void Add(IAccount acc) => accounts.Add(acc);
        public void Remove(IAccount acc) => accounts.Remove(acc);
        public void Accept(IVisitor visitor)
        {
            foreach (IAccount account in accounts)
            {
                account.Accept(visitor);
            }
        }
            
    }

    interface IAccount
    {
        void Accept(IVisitor visitor);
    }

    class Person : IAccount
    {
        public string  Name { get; set; }
        public string Number { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }

    class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAcc(this);
        }
    }
}
