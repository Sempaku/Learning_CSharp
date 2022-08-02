using System;
using System.Collections.Generic;
using System.Text;

namespace Строитель__Builder_
{

    class Client
    {
        void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
        }   
    }

    // распорядитель - создает объект, используя объекты Builder
    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    // определяет интерфейс для создания различных частей объекта Product
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    // представляет объект, который должен быть создан.
    // В данном случае все части объекта заключены в списке parts.
    class Product
    {
        List<object> parts = new List<object>();
        public void Add(string part)
        {
            parts.Add(part);
        }
    }

    // конкретная реализация Buildera.
    // Создает объект Product и определяет интерфейс для доступа к нему
    class ConcreteBuilder : Builder
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("Part A");
        }
        public override void BuildPartB()
        {
            product.Add("Part B");
        }
        public override void BuildPartC()
        {
            product.Add("Part C");
        }
        
        public override Product GetResult()
        {
            return product;
        }
    }


}
