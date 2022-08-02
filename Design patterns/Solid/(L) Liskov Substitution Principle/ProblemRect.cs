using System;
using System.Collections.Generic;
using System.Text;

namespace _L_Liskov_Substitution_Principle
{
    class ProblemRect
    {
        public static void Run()
        {
            Rectangle rect = new Square();
            TestRectangleArea(rect);
        }

        public static void TestRectangleArea(Rectangle rectangle)
        {
            rectangle.Height = 5;
            rectangle.Width = 10;
            if(rectangle.GetArea() != 50)
                Console.WriteLine("Incorrect area");
        }
    }
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : Rectangle
    {
        public override int Width 
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        
        }
    }
}
