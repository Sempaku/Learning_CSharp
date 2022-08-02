using System;
using System.Collections.Generic;
using System.Text;

namespace _O_Open_Closed_Principle_Template
{
    class TemplateKitchen
    {
        static public void Run()
        {
            CookTemplate cook = new CookTemplate("Sonya");
            MealBase[] menu = new MealBase[] { new SaladMeal(), new PotatoMeal() };
            cook.MakeDinner(menu);

        }
    }

    class CookTemplate
    {
        public string Name { get; set; }
        public CookTemplate(string name)
        {
            this.Name = name;
        }

        public void MakeDinner(MealBase[] menu)
        {
            foreach (MealBase meal in menu)
                meal.Make();
        }
    }

    abstract class MealBase
    {
        public void Make()
        {
            Prepare();
            Cook();
            FinalSteps();
        }

        protected abstract void Prepare();
        protected abstract void Cook();
        protected abstract void FinalSteps();
    }

    class PotatoMeal : MealBase
    {
        protected override void Prepare()
        {
            Console.WriteLine("Чистим и моем картошку");
        }

        protected override void Cook()
        {
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Варим около 30 минут");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
        }
        protected override void FinalSteps()
        {
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }

    class SaladMeal : MealBase
    {
        protected override void Cook()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
        }

        protected override void FinalSteps()
        {
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }

        protected override void Prepare()
        {
            Console.WriteLine("Моем помидоры и огурцы");
        }
    }
}
