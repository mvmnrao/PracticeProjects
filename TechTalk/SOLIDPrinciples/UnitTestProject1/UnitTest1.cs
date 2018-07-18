using System;
using System.Collections.Generic;
using LiskovSub;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Sixfor2x3Rectangle()
        //{
        //    Rectangle myRectangle = new Rectangle { Height = 2, Width = 3 };
        //    var result = AreaCalculator.CalculateArea(myRectangle);
        //    Assert.AreEqual(6, result);
        //}

        //[TestMethod]
        //public void Ninefor3x3Squre()
        //{
        //    Square mySquare = new Square { Height = 3 };
        //    var result = AreaCalculator.CalculateArea(mySquare);
        //    Assert.AreEqual(9, result);
        //}

        //[TestMethod]
        //public void TwentyFourfor4x6RectanglefromSquare()
        //{
        //    Rectangle newRectangle = new Square();
        //    newRectangle.Height = 4;
        //    newRectangle.Width = 6;
        //    var result = AreaCalculator.CalculateArea(newRectangle);
        //    Assert.AreEqual(24, result);
        //}

        [TestMethod]
        public void TwentyFourfor4x6Rectangleand9for3x3Square()
        {
            Shape shapeRect = new Rectangle { Height = 4, Width = 6 };
            Shape shapeSquare = new Square { Sides = 3 };

            Assert.AreEqual(24, shapeRect.Area());
            Assert.AreEqual(9, shapeSquare.Area());
        }
    }
}
