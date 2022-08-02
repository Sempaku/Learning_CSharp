using System;

// Фасад (Facade) представляет шаблон проектирования, который позволяет скрыть
// сложность системы с помощью предоставления упрощенного интерфейса для
// взаимодействия с ней.

// Когда использовать фасад?

// 1 Когда имеется сложная система, и необходимо упростить с ней работу.
// Фасад позволит определить одну точку взаимодействия между клиентом и системой.
// 2 Когда надо уменьшить количество зависимостей между клиентом и сложной системой.
// Фасадные объекты позволяют отделить, изолировать компоненты системы от клиента и
// развивать и работать с ними независимо.
// 3 Когда нужно определить подсистемы компонентов в сложной системе. Создание
// фасадов для компонентов каждой отдельной подсистемы позволит упростить
// взаимодействие между ними и повысить их независимость друг от друга.

//_________________________________________________________________________________

// Думаю, большинство программистов согласятся со мной, что писать в Visual Studio
// код одно удовольствие по сравнению с тем, как писался код ранее до появления
// интегрированных сред разработки. Мы просто пишем код,
// нажимаем на кнопку и все - приложение готово.
// В данном случае интегрированная среда разработки представляет собой фасад,
// который скрывает всю сложность процесса компиляции и запуска приложения.
// Теперь опишем этот фасад в программе на C#:

namespace Фасад__Facade_
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            TextEditor te = new TextEditor();
            Compiller comp = new Compiller();
            CLR clr = new CLR();

            VSFacade facade = new VSFacade(te, comp, clr);
            facade.Start();
            facade.Stop();
        }
    }

    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написание кода!");
        }
        public void Save()
        {
            Console.WriteLine("Сохранение кода");
        }
    }

    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Компиляция приложения");
        }
    }

    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение приложения");
        }
        public void Finish()
        {
            Console.WriteLine("Завершение работы приложения");
        }
    }

    class VSFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VSFacade(TextEditor te, Compiller comp, CLR clr)
        {
            this.textEditor = te;
            this.compiller = comp;
            this.clr = clr;
        }

        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }
}
