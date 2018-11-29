using CollectionsAndDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectManyOnEnumerable selectManyOnEnumerable = new SelectManyOnEnumerable();
            IEnumerable<string> concatedStrings = selectManyOnEnumerable.SelectManyAndConcatDifferentEnumerableLists();

            string pivotValue = "this is ; sample ; pivot";

            var qualityLevels = pivotValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            qualityLevels.Apply<string>(pivot =>
            {
                Console.WriteLine(pivot);
            });

            IEnumerable<int> groupIds = new int[] { 1, 2, 4, 3 };
            IEnumerable<string> qualities = new string[] { "HD", "UHD" };

            var result = groupIds.SelectMany(group => qualities);
            result.Apply(str => Console.WriteLine(str));


            Console.ReadKey();
        }
    }
}
