using System;
using System.Collections.Generic;
using System.Text;

namespace _O_Open_Closed_Principle
{
    class Kitchen
    {
        public static void Run()
        {
            NormalCook normalCook = new NormalCook("Sanya");
            normalCook.MakeDinner(new SaladMeal());
            Console.WriteLine();
            normalCook.MakeDinner(new PotatoMeal());

        }
    }
    class NormalCook
    {
        public string Name { get; set; }
        public NormalCook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner(IMeal meal)
        {
            meal.Make();
        }
    }

    interface IMeal
    {
        void Make();
    }

    class PotatoMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }

    class SaladMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }
    }
}
