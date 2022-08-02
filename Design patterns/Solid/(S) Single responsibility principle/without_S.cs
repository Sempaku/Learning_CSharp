using System;
using System.Collections.Generic;
using System.Text;

namespace _S_Принцип_единственной_обязанности
{
    class ReportWithoutSingleResponsibilityPrinciple
    {
        public string Text { get; set; } = "";
        public void GoToFirstPage() =>
            Console.WriteLine("Переход к первой странице");

        public void GoToLastPage() =>
            Console.WriteLine("Переход к последней странице");

        public void GoToPage(int pageNum) =>
            Console.WriteLine($"Переход к {pageNum} странице");

        public void Print()
        {
            Console.WriteLine("Печать отчета");
            Console.WriteLine(Text);
        }
    }
}

// Что если нам понадобится печатать отчет на консоль или передать его на принтер
// для физической печати на бумаге? Или вывести в файл?
// Сохранить в формате html, txt, rtf и т.д.?
// Очевидно, что мы можем для этого поменять нужным образом метод Print().
// Однако это вряд ли затронет остальные методы, которые относятся к навигации
// страницы.

// Также верно и обратное - изменение методов постраничной навигации вряд ли
// повлияет на возможность вывода текста отчета на принтер или на консоль.
// Таким образом, у нас здесь прослеживаются две причины для изменения, значит,
// класс Report обладает двумя обязанностями, и от одной из них этот класс надо
// освободить. Решением было бы вынести каждую обязанность в отдельный компонент
// (в данном случае в отдельный класс)

class ReportS
{
    public string Text { get; set; } = "";
    public void GoToFirstPage() =>
        Console.WriteLine("Переход к первой странице");

    public void GoToLastPage() =>
        Console.WriteLine("Переход к последней странице");

    public void GoToPage(int pageNumber) =>
        Console.WriteLine($"Переход к странице {pageNumber}");
}

class PrinterS
{
    public void PrintReport(ReportS report)
    {
        Console.WriteLine("Печать отчета");
        Console.WriteLine(report.Text);
    }
}

// Теперь печать вынесена в отдельный класс Printer, который через метод Print
// получает объект отчета и выводит его текст на консоль.

