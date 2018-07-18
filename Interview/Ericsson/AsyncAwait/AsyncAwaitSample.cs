using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class AsyncAwaitSample
    {
        public async Task<bool> DoAsync()
        {            
            Console.WriteLine("This is DoAsyncMethod");
            Task<bool> task = DoMoreAsync();
            Task<bool> taskMore = DoMoreAndMoreAsync();
            Console.WriteLine("Called DoMoreAsync");

            Console.WriteLine("await before");
            Task.WaitAll(task, taskMore);
            Console.WriteLine("Wait for All");

            ParallelOptions parallelOptions = new ParallelOptions();
            //parallelOptions.
            //Parallel.Invoke(ParallelOptions);
            //Task.Factory.StartNew()

            //Task.FromResult();
            //await Task.WhenAll();
            //Task.WaitAll()

            //await task;
            //await taskMore;
            //bool boolean = task.Result; //if we try to access Result of task, then it will wait till the result is receied, which is synchronous
            Console.WriteLine("await next");
            return task.Result;
        }

        private async Task<bool> DoMoreAsync()
        {
            Console.WriteLine("This is DoMoreAsync");

            long result = 0;
            for (long i = 0; i < 1000000; i++)
            {
                result += i;
            }

            //Console.WriteLine($"DoMoreAsync: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(10000);
            //return Task.FromResult<bool>(true); if we remove async in the mothod definition, this method 
            return true;
        }

        private async Task<bool> DoMoreAndMoreAsync()
        {
            await Task.Delay(10000);

            return true;
        }
    }
}
