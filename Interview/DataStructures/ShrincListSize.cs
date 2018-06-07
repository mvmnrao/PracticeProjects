using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ShrincListSize
    {
        public ShrincListSize()
        {
            List<int> listInt = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                listInt.Add(i);
            }

            Console.WriteLine($"ListLength: {listInt.Count}");

            listInt.RemoveRange(500, 499);

            Console.WriteLine($"ListLength: {listInt.Count}");

            listInt.TrimExcess();

            Console.WriteLine($"ListLength: {listInt.Count}");

            //for(int i = 400; i< listInt.Count; i++)
            //{
            //    listInt[i] = null;
            //}
        }
    }
}
