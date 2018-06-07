using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start..");

            Writer<IWriteTo> writer = new Writer<IWriteTo>(new WriteToConsole());
            writer.WriteMessage("Test message one");

            writer = new Writer<IWriteTo>(new WriteToFile());
            writer.WriteMessage("Test message two");

            //Below error is valid because of constrain applied for Writer class.
            //this error will go off if you remove generic constraint for Writer class but that will give run time exception.
            Writer<WriteToCloud> writerOne = new Writer<WriteToCloud>(new WriteToCloud());
            writerOne.WriteMessage("Test message three");

            Console.ReadKey();
        }
    }
}
