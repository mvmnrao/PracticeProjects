using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public class WriteToFile : IWriteTo
    {
        public void Write(string message)
        {
            File.WriteAllText("Message.txt", message);
            Console.WriteLine("Message has been written to file");
        }
    }
}
