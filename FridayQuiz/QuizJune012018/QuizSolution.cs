using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizJune012018
{
    public class QuizSolution
    {
        public QuizSolution()
        {
            string[] lines = File.ReadAllLines(Path.Combine(@"D:\Manik\PracticeProjects\FridayQuiz\QuizJune012018\Resource\CodingChallengeDictionary.txt"));

            Console.WriteLine($"Length: {lines.Length}");

            Solve(lines);
        }

        public int Solve(string[] lines)
        {
            int chainCount = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                string lineOne = lines[i];
                //string[] linesToCompare = lines.SkipWhile(line => line == strOne).ToArray();

                int currentChainCount = CompareEachLine(lineOne, lines);
                //for (int j = 0; j < linesToCompare.Length; j++)
                //{

                //}

                chainCount = chainCount > currentChainCount ? chainCount : currentChainCount;
            }

            return 0;
        }

        public int CompareEachLine(string lineOne, string[] lines)
        {
            int currentChainCount = 0;



            return currentChainCount;
        }

        public bool CompareLines(string lineOne, string lineTwo)
        {
            char[] charsOne = lineOne.ToCharArray();
            char[] charsTwo = lineTwo.ToCharArray();

            for(int i = 0; i < charsTwo.Length; i++)
            {

            }

            return false;
        }
    }
}
