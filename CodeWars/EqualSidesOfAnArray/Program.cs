using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSidesOfAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            FindEvenIndex(new int[] { 1, 2, 3, 4, 3, 2, 1 });

            Console.ReadKey();
        }

        public static int FindEvenIndex(int[] arr)
        {
            if (0 == arr.Sum())
            {
                return 0;
            }

            for (int i = 1; i < arr.Length - 1; i++)
            {
                int left = arr.ToList().GetRange(0, i).Sum();
                int right = arr.ToList().GetRange(i + 1, (arr.Length - 1) - i).Sum();
                if (left == right)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
