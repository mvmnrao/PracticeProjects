using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;

            int[][] a = new int[n][];
            int[,] b = new int[n, 2];

            a[0] = new int[3] { 1, 2, 3 };
            a[1] = new int[3] { 1, 2, 3 };
            a[2] = new int[3] { 1, 2, 3 };
            b[0, 0] = 1;
            b[1, 1] = 1;
            b[2, 2] = 1;

            //for (int i = 0; i < n; i++)
            //{
            //    a[i] = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            //}

            //int result = diagonalDifference(a);

            //Console.WriteLine(result);

            Console.ReadKey();
        }

        static int diagonalDifference(int[][] a)
        {
            int result = 0;



            return result;
        }
    }
}
