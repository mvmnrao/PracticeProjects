using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridayQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            //Math.Pow(5, 1);
            //Console.WriteLine(Convert.ToString((long)Math.Pow(5, 1), 2));

            //string binaryString = "11111101111111011111011101";
            //Console.WriteLine($"{binaryString}: {IsPowerOfFive(binaryString)}");
            //Console.WriteLine($"BinaryString: {binaryString}; Split Count: {GetSplitCount(binaryString)}");


            int a = 0b101;


            Console.WriteLine(abyfive(a));
            int abyfive(int n)
            {
                int divisor = n / 5;
                return n % 5 == 0 && divisor >= 5 ? abyfive(divisor) : divisor == 1 ? 1 : 0;
            }

            //string s1 = "One";
            //string s2 = new string(s1.ToCharArray());
            //string s3 = "Three";

            //Console.WriteLine($" {s1 == s2}; {s1 == s3}; {s1.Equals(s2)}; {s1.CompareTo(s2)}");

            Console.ReadLine();
        }

        private static int GetSplitCount(string binaryString)
        {
            int startIndex = 0;
            int length = binaryString.Length;
            int count = 0;

            while(length <= binaryString.Length)
            {
                string subString = binaryString.Substring(startIndex, length);

                if (IsPowerOfFive(subString))
                {
                    count++;
                    startIndex = length;
                    length = binaryString.Length - subString.Length;

                    if (startIndex >= binaryString.Length - 1)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Else case");
                    length -= 1;
                }                
            }
            

            return count;
        }

        private static bool IsPowerOfFive(string binaryString)
        {
            UInt64 intValue = Convert.ToUInt64(binaryString, 2);

            if ((intValue % 5) != 0)
            {
                return false;
            }

            return true;
        }
    }
}
