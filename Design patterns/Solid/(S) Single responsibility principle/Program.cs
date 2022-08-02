using System;
using System.Collections.Generic;
using System.IO;

// Принцип единственной обязанности (Single Responsibility Principle)
// --> Каждый компонент должен иметь одну и только одну причину для изменения

// В C# в качестве компонента может выступать класс, структура, метод.
// А под обязанностью здесь понимается набор действий, которые выполняют единую
// задачу. То есть суть принципа заключается в том, что класс/структура/метод должны
// выполнять одну единственную задачу. Весь функционал компонента должен быть
// целостным, обладать высокой связностью (high cohesion).

// Конкретное применение принципа зависит от контекста. В данном случае важно
// понимать, как изменяется компонент. Если он выполняет несколько различных
// действий, и они изменяются по отдельности, то это как раз тот случай, когда
// можно применить принцип единственной обязанности. То есть иными словами, у
// компонента несколько причин для изменения.

//__________________________________________________________________________________
// Допустим, нам надо определить класс отчета, по которому мы можем перемещаться
// по страницам и который можно выводить на печать
// --> without_S.cs
//__________________________________________________________________________________
// Стоит понимать, что обязанности в классах не всегда группируются по методам. Речь
// идет именно об обязанности компонента, в качестве которого может выступать не
// только тип (например, класс), но и метод или свойство. И вполне возможно, что
// в одном каком-то методе сгруппировано несколько обязанностей. 

namespace _S_Принцип_единственной_обязанности
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileStoreS store = new MobileStoreS(new ConsolePhoneReader(), 
        new GeneralPhoneBinder(), new GeneralPhoneValidator(), new TextPhoneSaver());
            store.Process();
        }
    }

    class Phone
    {
        public string Model { get; }
        public int Price { get; }
        public Phone(string model, int price)
        {
            Model = model; Price = price;
        }
    }

    class MobileStoreWithoutS
    {
        List<Phone> phones = new List<Phone>();

        public void Process()
        {
            //input 
            Console.WriteLine("Введите модель: ");
            string? model = Console.ReadLine();
            Console.WriteLine("Введите цену: ");

            // валидация
            bool result = int.TryParse(Console.ReadLine(), out var price);
            if (result == false || price <= 0 || string.IsNullOrEmpty(model))
            {
                throw new Exception("Введены некорректные данные");
            }
            else
            {
                phones.Add(new Phone(model, price));

                // сохраняем данные в файл

                using (StreamWriter sw = new StreamWriter(@"C:\Users\79172\Desktop\metanit\Паттерны проектирования\Solid\(S)Принцип единственной обязанности\store.txt", true))
                {
                    sw.WriteLine(model);
                    sw.WriteLine(price);
                }
                Console.WriteLine("Данные успешно сохранены");
            }
        }
    }
    // Класс имеет один единственный метод Process, однако этот небольшой метод,
    // содержит в себе как минимум четыре обязанности: ввод данных, их валидация,
    // создание объекта Phone и сохранение. В итоге класс знает абсолютно все: как
    // получать данные, как валидировать, как сохранять. При необходимости в него
    // можно было бы засунуть еще пару обязанностей. Такие классы еще называют
    // "божественными" или "классы-боги", так как они инкапсулируют в себе абсолютно
    // всю функциональность. Подобные классы являются одним из распространенных
    // анти-паттернов, и их применения надо стараться избегать.

    // Теперь изменим код класса, инкапсулировав все обязанности в отдельных классах
    class MobileStoreS
    {
        List<Phone> phones = new List<Phone>();

        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }
        public IPhoneSaver Saver { get; set; }

        public MobileStoreS(IPhoneReader reader, IPhoneBinder binder, 
            IPhoneValidator validator, IPhoneSaver saver)
        {
            Reader = reader;
            Binder = binder;
            Validator = validator;
            Saver = saver;
        }

        public void Process()
        {
            string?[] data = Reader.GetInputData();
            Phone phone = Binder.CreatePhone(data);
            if (Validator.IsValid(phone))
            {
                phones.Add(phone);
                Saver.Save(phone, @"C:\Users\79172\Desktop\metanit\Паттерны проектирования\Solid\(S)Принцип единственной обязанности\store.txt");
                Console.WriteLine("Данные успешно добавлены...");
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
        }
    }

    interface IPhoneSaver
    {
        void Save(Phone phone, string v);
    }

    class TextPhoneSaver: IPhoneSaver
    {
        public void Save(Phone phone, string fileName)
        {
            using StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(phone.Model);
            sw.WriteLine(phone.Price);
        }
    }


    interface IPhoneValidator
    {
        bool IsValid(Phone phone);
    }
    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone phone) =>
            !string.IsNullOrEmpty(phone.Model) && phone.Price > 0;
    }


    interface IPhoneBinder
    {
        Phone CreatePhone(string[] data);
    }

    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(string[] data)
        {
            if (data is { Length:2} && data[0] is string model &&
                model.Length > 0 && int.TryParse(data[1], out var price))
            {
                return new Phone(model, price);
            }
            throw new Exception("Введены некорректные данные");
        }
        
    }

    public interface IPhoneReader
    {
        string[] GetInputData();
    }

    class ConsolePhoneReader : IPhoneReader
    {
        public string?[] GetInputData()
        {
            Console.WriteLine("Input model: ");
            string? model = Console.ReadLine();
            Console.WriteLine("Input price: ");
            string? price = Console.ReadLine();
            return new string?[] { model, price };
        }
    }
}

// Распространенные случаи отхода от принципа SRP
// Нередко принцип единственной обязанности нарушает при смешивании в одном классе
// функциональности разных уровней. Например, класс производит вычисления и
// выводит их пользователю, то есть соединяет в себя бизнес-логику и работу с
// пользовательским интерфейсом. Либо класс управляет сохранением/получением
// данных и выполнением над ними вычислений, что также нежелательно.
// Класс следует применять только для одной задачи - либо бизнес-логика,
// либо вычисления, либо работа с данными.

// Другой распространенный случай - наличие в классе или его методах абсолютно
// несвязанного между собой функционала.


// Распространенные сценарии выделения компонентов:
// * Логика хранения данных
// * Валидация
// * Механизм уведомлений пользователя
// * Обработка ошибок
// * Логгирование
// * Выбор класса или создание его объекта
// * Форматирование
// * Парсинг
// * Маппинг данных



