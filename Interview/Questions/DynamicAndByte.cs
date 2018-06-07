using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class DynamicAndByte
    {
        public void Execute()
        {
            byte num = 100;
            dynamic val = num;
            var myVar = 1;
            Console.WriteLine(val.GetType());
            val += 100;
            Console.WriteLine(val.GetType());
        }
    }
}
