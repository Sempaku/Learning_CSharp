using System;
using System.Text;

// Строитель (Builder) - шаблон проектирования, который инкапсулирует создание объекта
// и позволяет разделить его на различные этапы.

// Когда использовать паттерн Строитель?
//   1 Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот
// объект состоит и как эти части связаны между собой
//   2 Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания

//_____________________________________________________________________________________________

// Рассмотрим применение паттерна на примере выпечки хлеба.
// Как известно, даже обычный хлеб включает множество компонентов.



namespace Строитель__Builder_
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Baker baker = new Baker();
            BreadBuilder builder = new RyeBreadBuilder();
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());

            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString()) ;
            Console.Read();
        }
    }

    class Flour //мука
    {
        public string Sort { get; set; }
    }

    class Salt { }

    class Additives // добавки
    {
        public string Name { get; set; }
    }

    class Bread
    {
        public Flour Flour { get; set; }
        public Salt Salt { get; set; }
        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Flour != null)
                sb.Append(Flour.Sort + '\n');
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + "\n");
            return sb.ToString();
        }
    }

    abstract class BreadBuilder
    {
        public Bread Bread { get; set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }
        public abstract void SetFloar();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFloar();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    class RyeBreadBuilder : BreadBuilder // ржаной
    {
        public override void SetFloar()
        {
            this.Bread.Flour = new Flour() { Sort = "Ржаная мука 1 сорт" };
        }
        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }
        public override void SetAdditives()
        {
            //not used
        }
    }
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFloar()
        {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }
        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }
}
