using System;

// Паттерн Итератор (Iterator) предоставляет абстрактный интерфейс для
// последовательного доступа ко всем элементам составного объекта без
// раскрытия его внутренней структуры.


// Когда использовать итераторы?
//     1 Когда необходимо осуществить обход объекта без раскрытия его
// внутренней структуры
//     2 Когда имеется набор составных объектов, и надо обеспечить единый
// интерфейс для их перебора
//     3 Когда необходимо предоставить несколько альтернативных вариантов
// перебора одного и того же объекта
//__________________________________________________________________________

// Допустим, у нас есть класс читателя, который хочет получить информацию о книгах,
// которые находятся в библиотеке. И для этого надо осуществить перебор объектов
// с помощью итератора



namespace Итератор__Iterator_
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

        }
    }

    class Book
    {
        public string Name { get; set; }
    }
    class Library : IBookNumerable
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
                new Book{Name = "C# bible"},
                new Book{Name = "Fight club"},
                new Book{Name = "II World War"}
            };
        }
        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }

    class LibraryNumerator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            if (index < aggregate.Count)
                return true;
            return false;
        }
        public Book Next()
        {
            return aggregate[index++];
        }
    }

    class Reader
    {
        public void SeeBooks(Library lib)
        {
            IBookIterator iterator = lib.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
            
        }
    }

    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }


}
