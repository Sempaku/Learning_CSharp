using System;

// Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее
// созданных объектов-прототипов. То есть по сути данный паттерн предлагает технику
// клонирования объектов.

// Когда использовать Прототип?
//     1 Когда конкретный тип создаваемого объекта должен определяться
// динамически во время выполнения
//     2 Когда нежелательно создание отдельной иерархии классов фабрик для создания
// объектов-продуктов из параллельной иерархии классов (как это делается, например,
// при использовании паттерна Абстрактная фабрика)
//     3 Когда клонирование объекта является более предпочтительным вариантом нежели его
// создание и инициализация с помощью конструктора. Особенно когда известно,
// что объект может принимать небольшое ограниченное число возможных состояний.

//_________________________________________________________________________________________

namespace Прототип__Prototype_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рассмотрим клонирование на примере фигур - прямоугольников и кругов
            IFigure figure = new Rectangle(10, 20);
            IFigure cloneFigure = figure.Clone();
            figure.GetInfo();
            cloneFigure.GetInfo();

            figure = new Circle(30);
            cloneFigure = figure.Clone();
            figure.GetInfo();
            cloneFigure.GetInfo();

            Console.Read();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Прямоугольник с h: {height} и w: {width}");
        }
    }

    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Круг с радиусом: {radius}");
        }
    }
}
