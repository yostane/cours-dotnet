using System.Threading.Tasks;
using System;
using System.Threading;
namespace Csharp
{
    class ThreadDemo
    {
        public static void PrintAfterDelay5()
        {
            Thread.Sleep(5000);
            Console.WriteLine("5s après");
        }

        public static void PrintAfterDelay3()
        {
            Thread.Sleep(3000);
            Console.WriteLine("3s après");
        }
        public static void Run()
        {
            // thread: un traitment concurrent
            Thread thread1 = new Thread(new ThreadStart(PrintAfterDelay5));
            thread1.Name = "5S";
            Thread thread2 = new Thread(new ThreadStart(PrintAfterDelay3));
            thread2.Name = "3S";

            thread1.Start();
            thread2.Start();
            Console.WriteLine("Threads démarrés");
        }
    }

    class AsyncDemo
    {
        public static async Task Run()
        {
            var task1 = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"Task 1 {i}");
                }
            });

            var task2 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Task 2 {i}");
                }
            });
            Task.WaitAll(task2, task1);
            Console.WriteLine("Fin");

            int r = await GetRandomValueAsync();
            Console.WriteLine($"Async random {r}");
        }

        // Conseil (à confirmer):toute fonction qui dure dure plus de 11ms, faut la faire en Async
        // convention, tout ce qui retourne Task doit être suffixé par Async
        public static Task<int> GetRandomValueAsync()
        {
            Task<int> task = Task.Run(async () =>
            {
                await Task.Delay(2000);
                var r = new Random();
                return r.Next();
            });
            return task;
        }
    }
}