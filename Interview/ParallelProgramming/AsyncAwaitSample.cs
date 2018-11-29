using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming
{
    public class AsyncAwaitSample
    {
        public async Task<string> MethodOneAsync()
        {
            Console.WriteLine("MethodOne Async - 1");
            Task<string> task = MethodTwoAsync();

            Console.WriteLine("MethodOne Async - 2");

            var result = await MethodTwoAsync();
            Console.WriteLine(result);

            Console.WriteLine(task.Result);
            return task.Result;
        }

        private async Task<string> MethodTwoAsync()
        {
            Console.WriteLine("MethodTwo Async");
            return await Task.FromResult(MethodOne());
        }

        private string MethodOne()
        {
            Thread.Sleep(2000);
            return "Simple string";
        }

        public string MethodTwo()
        {
            string result = MethodTwoAsync().GetAwaiter().GetResult();
            Console.WriteLine(result);
            return result;
        }
    }
}
