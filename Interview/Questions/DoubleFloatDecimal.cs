using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class DoubleFloatDecimal
    {
        public void Execute()
        {
            double d = 1D / 3;
            float f = 1F / 3;
            decimal de = 1M / 3;

            Console.WriteLine($"d = {d}; f = {f}; de = {de}");

            double d1 = 111112D / 3;
            float f1 = 111112F / 3;
            decimal de1 = 111112M / 3;

            Console.WriteLine($"d1 = {d1}; f1 = {f1}; de1 = {de1}");

            double d2 = 111112 / 3;
            float f2 = 111112 / 3;
            decimal de2 = 111112 / 3;

            Console.WriteLine($"d2 = {d2}; f2 = {f2}; de2 = {de2}");
        }
    }
}
