using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

// Паттерн Заместитель (Proxy) предоставляет объект-заместитель, который управляет
// доступом к другому объекту. То есть создается объект-суррогат, который может
// выступать в роли другого объекта и замещать его.

// Когда использовать прокси?

// 1 Когда надо осуществлять взаимодействие по сети, а объект-проси должен
// имитировать поведения объекта в другом адресном пространстве. Использование
// прокси позволяет снизить накладные издержки при передачи данных через сеть.
// Подобная ситуация еще называется удалённый заместитель (remote proxies)

// 2 Когда нужно управлять доступом к ресурсу, создание которого требует больших
// затрат. Реальный объект создается только тогда, когда он действительно может
// понадобится, а до этого все запросы к нему обрабатывает прокси-объект.
// Подобная ситуация еще называется виртуальный заместитель (virtual proxies)

// 3 Когда необходимо разграничить доступ к вызываемому объекту в зависимости от
// прав вызывающего объекта. Подобная ситуация еще называется защищающий заместитель
// (protection proxies)

// 4 Когда нужно вести подсчет ссылок на объект или обеспечить потокобезопасную
// работу с реальным объектом. Подобная ситуация называется "умные ссылки"
// (smart reference)

// _________________________________________________________________________________

// Рассмотрим применение паттерна.
// Допустим, мы взаимодействуем с базой данных через Entity Framework.
// У нас есть модель и контекст данных:

// Класс Page представляет отдельную страницу книги, у которой есть номер и текст.
// Взаимодействие с базой данных может уменьшить производительность приложения.
// Для оптимизации приложения мы можем использовать паттерн Прокси.
// Для этого определим репозиторий и его прокси-двойник:

namespace Заместитель__Прокси_
{
    class Program
    {
        static void Main(string[] args)
        {
            using(IBook book = new BookStoreProxy())
            {
                //read first page
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);

                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);

                //return back to 1 page
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }
        }
    }

    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int num)
        {
            return db.Pages.FirstOrDefault(p => p.Number == num);
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }

    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }

        public Page GetPage(int num)
        {
            Page page = pages.FirstOrDefault(p => p.Number == num);
            if (page == null)
            {
                if (bookStore == null)
                {
                    bookStore = new BookStore();
                }
                page = bookStore.GetPage(num);
                pages.Add(page);
            }
            return page;
        }
        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }

}
