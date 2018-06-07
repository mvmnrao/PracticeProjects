using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public class WriteToCloud
    {
        public void Write(string message)
        {
            Console.WriteLine($"Message {message} will be written to cloud");
        }
    }
}
