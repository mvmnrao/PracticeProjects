using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class HashIfCondition
    {
        private void Execute()
        {
#if (!pi)
            Console.WriteLine("i");
#else
            Console.WriteLine("PI undefined");
#endif
            Console.WriteLine("ok");
        }
    }
}
