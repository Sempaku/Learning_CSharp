using System;

namespace Фабричный_метод_Factory_Method_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Допустим, мы создаем программу для сферы строительства. Возможно, вначале
            //мы захотим построить многоэтажный панельный дом. И для этого выбирается
            //соответствующий подрядчик, который возводит каменные дома. Затем нам захочется
            //построить деревянный дом и для этого также надо будет выбрать нужного подрядчика

            Developer dev = new PanelDeveloper("OOO PanelH");
            House housePanel = dev.Create();

            dev = new WoodDeveloper("WWW WoodStack");
            House douseWood = dev.Create();

        }
    }

    abstract class Developer
    {
        public string Name { get; set; }
        public Developer(string name)
        {
            Name = name;
        }
        abstract public House Create();
    }


    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name) { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name) { }
        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен.");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен.");
        }
    }
}
