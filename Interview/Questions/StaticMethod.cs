using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class StaticMethod
    {
        static void arrayMethod(int[] a, ref int[] c)
        {
            int[] b = new int[5];
            int[] d = new int[20];
            a = b;
            c = d;
        }
        public static void Execute()
        {
            int[] arr = new int[10];
            int[] arr1 = new int[15];
            arrayMethod(arr, ref arr1);
            Console.WriteLine("arr.Length:" + arr.Length);

            Console.WriteLine("arr1.Length:" + arr1.Length);
        }
    }
}
