using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz27July
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = File.ReadAllLines("AnnieWalk.txt");
            string steps = arguments[0];
            int length = int.Parse(arguments[1]);
            int start = int.Parse(arguments[2]);
            int end = int.Parse(arguments[3]);

            Console.WriteLine($"Full string: {steps}");

            Console.WriteLine(SubSequences(steps, end - start));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static int SubSequences(string str, int distance)
        {
            HashSet<string> subSequenceStrings = new HashSet<string>();
            double[] ints = new double[str.Length];
            int matchingString = 0;

            for(int i = 0; i < str.Length; i++)
            {
                ints[i] = ((int)str[i] == 114) ? 1 : -1;
            }

            int combinations = (int)Math.Pow(2, str.Length) - 1;

            for (int i = 1; i <= combinations; i++)
            {
                string binary = Convert.ToString(i, 2);
                for (int l = binary.Length; l < str.Length; l++)
                {
                    if (ints[l] == -1)
                    {
                        binary = '0' + binary;
                    }
                    else
                    {
                        break;
                    }
                }
                double movedSteps = 0;
                string subString = "";
                for(int j = 0; j < binary.Length; j++)
                {
                    movedSteps += ints[j];
                    if (binary[j] == '1')
                    {
                        subString += str[j];                        
                    }
                    else
                    {
                        subString = str[j] + subString;
                    }
                }

                if(movedSteps == distance && !subSequenceStrings.Contains(subString))
                {
                    matchingString++;
                    subSequenceStrings.Add(subString);
                    Console.WriteLine(subString);// + " - " + i);
                }
            }

            return matchingString;
        }
    }
}