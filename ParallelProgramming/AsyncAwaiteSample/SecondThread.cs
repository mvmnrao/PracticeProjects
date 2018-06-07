using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaiteSample
{
    public class SecondThread
    {
        public async Task<string> SecondMethod()
        {
            Console.WriteLine("Second Method Start");

            string message = "Test Message - Second Method";

            ThirdThread thirdThread = new ThirdThread();
            string returnedMessage = await thirdThread.ThirdMethod();

            Console.WriteLine(returnedMessage);
            Console.WriteLine("Second Method End");

            return message;
        }

        public Task<string> SecondMethodWithouAwait()
        {
            Console.WriteLine("Second Method without await Start");

            string message = "Test Message - Second Method";

            ThirdThread thirdThread = new ThirdThread();

            Task<string> task = Task.Run(() => {
                Task<string> taskOne = thirdThread.ThirdMethod();
                Console.WriteLine(taskOne.Result + "; without await");
                Thread.Sleep(3000);

                return message + " - " + taskOne.Result;
            });            
            
            Console.WriteLine("Second Method without await End");            

            return task;
        }
    }
}
