using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaiteSample
{
    public class MainThread
    {
        public async void MainMethod()
        {
            SecondThread secondThread = new SecondThread();

            Console.WriteLine("Main method with await Start");

            string message = await secondThread.SecondMethod();
            Console.WriteLine(message);

            Console.WriteLine("Main method with await End");
        }

        public void MainMethodWithoutAwait()
        {
            Console.WriteLine("Main method without await Start");

            SecondThread secondThread = new SecondThread();
            Task<string> taskOne = secondThread.SecondMethodWithouAwait();
            Console.WriteLine(taskOne.Result);

            Console.WriteLine("Main method without await End");
        }
    }
}
