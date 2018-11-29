using System;

namespace SimplePuzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start..!");
            PrintNums(100);
            Console.ReadKey();
        }

        private static void PrintNums(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
