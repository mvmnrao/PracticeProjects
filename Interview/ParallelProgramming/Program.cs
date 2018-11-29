using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started...");
            DataParallelism dataParallelism = new DataParallelism();

            ParallelLoopResult result = Parallel.For(0, 10, index => dataParallelism.ReturnRandomNumber(index, 15));

            Console.WriteLine(dataParallelism.Total);

            int total = 0;
            Parallel.For(0, 10,
                  i => {
                      Thread.Sleep(1000);
                      Console.WriteLine($"Index: {i}; ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                      Interlocked.Add(ref total, i);
                  });

            Console.WriteLine($"Total: {total};");

            Console.WriteLine("Parallel For loop with Thread-Local variable:");
            ParallelForWithCurrentThreadState();
            Console.WriteLine("Parallel For loop with Thread-Local variable end.");

            AsyncAwaitSample asyncAwaitSample = new AsyncAwaitSample();
            asyncAwaitSample.MethodOneAsync().GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static void ParallelForWithCurrentThreadState()
        {
            int[] nums = Enumerable.Range(0, 12).ToArray();
            long total = 0;

            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables
            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            {
                subtotal += nums[j];

                if(j == 8)
                {
                    subtotal += 15;
                }

                if(j > 10)
                {
                    Console.WriteLine("Breaking loop because j is greater than 10.");
                    loop.Break();
                }
                else
                {
                }

                Console.WriteLine($"  ThreadId: {Thread.CurrentThread.ManagedThreadId}; Index: {j}; Subtotal: {subtotal};");

                return subtotal;
            },
                (x) =>
                {
                    Console.WriteLine($"    Local final has been called with {x}");
                    Interlocked.Add(ref total, x);
                }
            );

            Console.WriteLine("The total is {0:N0}", total);
        }
    }
}
