using System;
using System.Collections.Generic;
using System.Text;

namespace Schema_Composite_
{
    //Client: клиент, который использует компоненты
    class Client
    {        
        public static void Run()
        {
            Component root = new Composite("root");
            Component leaf = new Leaf("leaf");
            Component subtree = new Composite("subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }       
    }

    // Component: определяет интерфейс для всех компонентов в древовидной структуре
    abstract class Component
    {
        protected string name;

        public Component(string n)
        {
            name = n;
        }
        public abstract void Display();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
    }

    // Composite: представляет компонент, который может содержать другие компоненты
    // и реализует механизм для их добавления и удаления
    class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string n) : base(n)
        {
            //
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display()
        {
            Console.WriteLine(name);

            foreach (Component c in children)
            {
                c.Display();
            }
        }
    }

    // Leaf: представляет отдельный компонент, который не может содержать другие
    // компоненты
    class Leaf : Component
    {
        public Leaf(string n    ) : base(n)
        {
           //
        }
        public override void Display()
        {
            Console.WriteLine(name);
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
    
}
