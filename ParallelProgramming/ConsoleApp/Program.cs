using AsyncAwaiteSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            MainThread mainThread = new MainThread();
            //mainThread.MainMethod();

            Thread.Sleep(5000);
            mainThread.MainMethodWithoutAwait();

            Console.ReadKey();
        }
    }
}
