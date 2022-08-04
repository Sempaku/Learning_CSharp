using System;

// ________________________________________________________________________________

// Теперь рассмотрим реальное применение.
// Существует множество программистов, но одни являются фрилансерами,
// кто-то работает в компании инженером, кто-то совмещает работу в компании и
// фриланс. Таким образом, вырисовывается иерархия различных классов программистов.
// Но эти программисты могут работать с различными языками и технологиями.
// И в зависимости от выбранного языка деятельность программиста будет отличаться.
// Для решения описания данной задачи в программе на C# используем паттерн Мост:

namespace Мост__Bridge_
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            // пришел заказ, но теперь нужен C#
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();

        }
    }

    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора C++ компилируем программу в бинарный код");
        }
        public void Execute()
        {
            Console.WriteLine("Запускаем исполняемый файл программы");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора Roslyn компилируем исходный код в файл exe");
        }
        public void Execute()
        {
            Console.WriteLine("JIT компилирует программу бинарный код");
            Console.WriteLine("CLR выполняет скомпилированный бинарный код");
        }
    }

    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }

        public Programmer(ILanguage lang)
        {
            language = lang;
        }

        public virtual void DoWork()
        {
            language.Build();
            language.Execute(); 
        }
        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {

        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем оплату за выполненный заказ.");
        }
    }

    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang) : base(lang)
        {

        }

        public override void EarnMoney()
        {
            Console.WriteLine("Получаем зарплату в конце месяца.");
        }
    }
}
