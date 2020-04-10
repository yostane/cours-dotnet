using System.Threading.Tasks;
using System;

namespace async_example
{
    class Program
    {
        static Task RunForLoopAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Task 1 {i}");
                }
            });
        }

        static async Task<int> DoSomethingAsync()
        {
            await RunForLoopAsync();
            return 100;
        }

        static async Task Main(string[] args)
        {
            await RunForLoopAsync();
            int result = await DoSomethingAsync();
            Console.WriteLine($"Hello World! {result}");
        }
    }
}
