//using Schema_Composite_;
using System;
using System.Collections.Generic;

// Паттерн Компоновщик (Composite) объединяет группы объектов в древовидную
// структуру по принципу "часть-целое и позволяет клиенту одинаково работать как
// с отдельными объектами, так и с группой объектов.

// Образно реализацию паттерна можно представить в виде меню, которое имеет
// различные пункты. Эти пункты могут содержать подменю, в которых, в свою очередь,
// также имеются пункты. То есть пункт меню служит с одной стороны частью меню,
// а с другой стороны еще одним меню. В итоге мы однообразно можем работать как
// с пунктом меню, так и со всем меню в целом.

// ________________________________________________________________________________

// Когда использовать компоновщик?

// 1 Когда объекты должны быть реализованы в виде иерархической древовидной
// структуры
// 2 Когда клиенты единообразно должны управлять как целыми объектами, так и их
// составными частями. То есть целое и его части должны реализовать один и тот
// же интерфейс

// _______________________________________________________________________________

// Рассмотрим простейший пример. Допустим, нам надо создать объект файловой
// системы. Файловую систему составляют папки и файлы. Каждая папка также может
// включать в себя папки и файлы. То есть получается древовидная иерархическая
// структура, где с вложенными папками нам надо работать также, как и с папками,
// которые их содержат. Для реализации данной задачи и воспользуемся паттерном
// Компоновщик:





namespace Компоновщик__Composite_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client.Run();
            Console.WriteLine("________________");

            Component fileSystem = new Dir("\\File System\\");
            Component disk = new Dir("\\Disk C\\");

            Component pictureFIle = new File("\\kekw.png");
            disk.Add(pictureFIle);
            disk.Add(new File("bookHowReadBook.pdf"));
            fileSystem.Add(disk);
            fileSystem.Print();
        }
    }

    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public virtual void Add(Component c) { }
        public virtual void Remove(Component c) { }
        public virtual void Print() => Console.WriteLine(name);
    }

    class Dir : Component
    {
        private List<Component> components = new List<Component>();

        public Dir(string name  ) : base(name)
        {
            //empty
        }

        public override void Add(Component c)
        {
            components.Add(c);
        }
        public override void Remove(Component c)
        {
            components.Remove(c);
        }
        public override void Print()
        {
            Console.WriteLine("Узел: " + name);
            Console.WriteLine("Подузлы: ");
            for(int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
    }

    class File : Component
    {
        public File(string n) : base(n)
        {

        }
    }
}
