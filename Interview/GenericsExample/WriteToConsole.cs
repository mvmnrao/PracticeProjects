using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public class WriteToConsole : IWriteTo
    {
        public void Write(string message)
        {
            Console.WriteLine($"I write this '{message}' message to Console.");
        }
    }
}
