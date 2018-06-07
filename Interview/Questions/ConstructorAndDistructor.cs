using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class ConstructorAndDistructor
    {
        public ConstructorAndDistructor()
        {
            Console.WriteLine("This is constructor");
        }

        /// <summary>
        /// This is called while the object is being disposed
        /// </summary>
        ~ConstructorAndDistructor()
        {
            Console.WriteLine("This is distructor");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
