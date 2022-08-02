using System;
using System.Collections.Generic;
using System.Text;

// Каждый класс имеет свой набор свойств и с помощью метода ToHtml() создает таблицу
// со значениями этих свойств. Но допустим, мы решили добавить потом еще
// сериализацию в формат xml. Задача относительно проста: добавить в интерфейс
// IAccount новый метод ToXml() и реализовать его в классах Person и Company.

// Но еще через некоторое время мы захотим добавить сериализацию в формат json.
// Однако в будущем могут появиться новые форматы, которые мы также захотим
// поддерживать. Частое внесение изменение в фиксированную структуру классов в
// данном случае не будет оптимально.

namespace Without_Pattern_Посетитель__Visitor_
{
    class WITHOUTPATTERN
    {
        static void Run()
        {

        }
    }

    interface IAccount
    {
        void ToHtml();
    }

    //физ лицо
    class Person: IAccount
    {
        public string FIO { get; set; }
        public string AccNumber { get; set; }

        public void ToHtml()
        {
            string result = "<table><tr><td>Свойство</td><td>Значение</td></tr></table>";
            result += "<tr><td>FIO<td><td>" + FIO + "</td></tr>";
            result += "<tr><td>Number<td><td>" + AccNumber + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }
    class Company : IAccount
    {
        public string Name { get; set; } // название
        public string RegNumber { get; set; } // гос регистрационный номер
        public string Number { get; set; } // номер счета

        public void ToHtml()
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }

}
