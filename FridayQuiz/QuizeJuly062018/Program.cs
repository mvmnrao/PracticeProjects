using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeJuly062018
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> stoneSizes = File.ReadAllLines(@"D:\Manik\PracticeProjects\FridayQuiz\QuizeJuly062018\PrisonerStone.txt")
                                    .Select(int.Parse).ToList<int>();
            int size = stoneSizes[0];
            int remainingStoneWeight = 0;
            stoneSizes.RemoveAt(0);

            while((stoneSizes.Count > 1) || (stoneSizes.Count > 0 && remainingStoneWeight > 0))
            {
                int maxOne = remainingStoneWeight;
                int maxTwo;

                if (remainingStoneWeight == 0)
                {
                    maxOne = stoneSizes[size - 2];
                    stoneSizes.RemoveAt(size-- - 2);
                }
                maxTwo = stoneSizes[size - 1];
                stoneSizes.RemoveAt(size-- - 1);

                remainingStoneWeight = Math.Abs(maxOne - maxTwo);              
            }

            if(stoneSizes.Count > 0)
            {
                remainingStoneWeight = Math.Abs(remainingStoneWeight - stoneSizes[0]);
            }

            Console.WriteLine(remainingStoneWeight);

            Console.ReadKey();
        }
    }
}
