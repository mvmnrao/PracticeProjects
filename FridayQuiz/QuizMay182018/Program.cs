using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMay182018
{
    class Program
    {
        static void Main(string[] args)
        {
            NonDegenerateHandler handler = new NonDegenerateHandler(
                                                                    7, 
                                                                    new int[] { 10, 1, 9, 4, 5, 6, 10 },
                                                                    new int[] { 5, 7, 3, 9, 4, 10, 10 },
                                                                    new int[] { 5, 4, 8, 10, 1, 8, 8 });
            foreach (string i in handler.ValidateTrianglesAndReturnFlags())
            {
                Console.WriteLine(i);
            }            

            Console.ReadKey();
        }

        
    }
}
