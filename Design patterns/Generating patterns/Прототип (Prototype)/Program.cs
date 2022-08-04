using System;

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
