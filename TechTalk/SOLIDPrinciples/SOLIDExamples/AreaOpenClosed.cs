using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }


        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    area += rectangle.Width * rectangle.Height; //We can use Math.Pow to get R square.
                }
                else
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }
            }

            return area;
        }
    }

    //public abstract class Shape
    //{
    //    public abstract double Area();
    //}

    //public class Rectangle : Shape
    //{
    //    public double Width { get; set; }
    //    public double Height { get; set; }
    //    public override double Area()
    //    {
    //        return Width * Height;
    //    }
    //}

    //public class Circle : Shape
    //{
    //    public double Radius { get; set; }
    //    public override double Area()
    //    {
    //        return Radius * Radius * Math.PI;
    //    }
    //}

    //public double Area(Shape[] shapes)
    //{
    //    double area = 0;
    //    foreach (var shape in shapes)
    //    {
    //        area += shape.Area();
    //    }

    //    return area;
    //}

}
