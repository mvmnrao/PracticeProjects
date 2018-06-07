using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMay182018
{
    public class NonDegenerateHandler
    {
        private int _noOfTriangles = 0;
        private int[] _aSides;
        private int[] _bSides;
        private int[] _cSides;

        public NonDegenerateHandler(int noOfTriangles, int[] aSides, int[] bSides, int[] cSides)
        {
            _noOfTriangles = noOfTriangles;
            _aSides = aSides;
            _bSides = bSides;
            _cSides = cSides;
        }

        public string[] ValidateTrianglesAndReturnFlags()
        {
            string[] result = new string[_noOfTriangles];

            for (int i = 0; i < _noOfTriangles; i++)
            {
                result[i] = IsNonDegenerate(_aSides[i], _bSides[i], _cSides[i]).ToString();
            }

            return result;
        }

        private bool IsNonDegenerate(int a, int b, int c)
        {
            double perimeter = (a + b + c) / 2;
            double forSqrt = perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c);
            double area = Math.Sqrt(forSqrt);

            if(area > 0)
            {
                return true;
            }

            return false;
        }
    }
}
