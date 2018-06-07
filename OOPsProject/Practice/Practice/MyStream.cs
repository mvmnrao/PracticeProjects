using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class MyStream
    {
        public string ReadStreamLineByLine()
        {
            byte[] toBytes = Encoding.ASCII.GetBytes("Heloow.");
            Stream st = new MemoryStream(toBytes);

            StreamReader re = new StreamReader(st);

            Console.WriteLine(re.ReadLine());
            return "";
        }
    }
}
