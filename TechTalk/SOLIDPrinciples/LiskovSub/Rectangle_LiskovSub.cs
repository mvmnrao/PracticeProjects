﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSub
{
    //public class Rectangle
    //{
    //    public virtual int Height { get; set; }
    //    public virtual int Width { get; set; }
    //}

    //public class Square : Rectangle
    //{
    //    private int _height;
    //    private int _width;
    //    public override int Height
    //    {
    //        get
    //        {
    //            return _height;
    //        }
    //        set
    //        {
    //            _height = value;
    //            _width = value;
    //        }
    //    }
    //    public override int Width
    //    {
    //        get
    //        {
    //            return _width;
    //        }
    //        set
    //        {
    //            _width = value;
    //            _height = value;
    //        }
    //    }

    //}

    //public class AreaCalculator
    //{
    //    public static int CalculateArea(Rectangle r)
    //    {
    //        return r.Height * r.Width;
    //    }

    //    public static int CalculateArea(Square s)
    //    {
    //        return s.Height * s.Height;
    //    }
    //}

    public abstract class Shape
    {
        public abstract int Area();
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override int Area()
        {
            return Height * Width;
        }
    }

    public class Square : Shape
    {
        public int Sides;
        public override int Area()
        {
            return Sides * Sides;
        }

    }
}
