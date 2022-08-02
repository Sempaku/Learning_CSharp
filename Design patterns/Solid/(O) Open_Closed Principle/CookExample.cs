using System;
using System.Collections.Generic;
using System.Text;

namespace _O_Open_Closed_Principle
{

    class Process
    {
        public static void Run()
        {
            Cook cook = new Cook("Diman");
            cook.MakeDinner();
        }
    }
    class Cook
    {
        public string Name { get; set; }
        public Cook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }
}
