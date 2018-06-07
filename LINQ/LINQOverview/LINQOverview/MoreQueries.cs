using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQOverview
{
    public class MoreQueries
    {
        public MoreQueries()
        {
            string sampleStr = "This is a sample string to experiment with LinQ queries";

            string[] words = sampleStr.Split(' ');

            var query = from obj in words
                        group obj by obj.Length into gr // obj.Substring(0, 1) into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };


            foreach(var obj in query)
            {
                Console.WriteLine($"Words of Length: {obj.Length}");
                foreach(string word in obj.Words)
                {
                    Console.WriteLine(word);
                }
            }
            Console.WriteLine("======================================");

            var query1 = words
                         .GroupBy(w => w.Length, w => w.ToUpper())
                         .OrderBy(w => w.Key)
                         .Select(g => new { Length = g.Key, Words = g });

            foreach (var obj in query1)
            {
                Console.WriteLine($"Words of Length: {obj.Length}");
                foreach (string word in obj.Words)
                {
                    Console.WriteLine(word);
                }
            }            
        }
    }
}
