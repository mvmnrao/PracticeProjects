using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaiteSample
{
    public class ThirdThread
    {
        public Task<string> ThirdMethod()
        {
            Console.WriteLine("Third Method Start");

            string message = "Test Message - Third Method";

            Task<string> task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return message;
            });
            
            Console.WriteLine("Third Method End");

            return task;
        }
    }
}
