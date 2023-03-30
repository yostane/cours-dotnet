using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
namespace Csharp.Assignment
{
    public class Assignment03
    {
        private static Task<int> GeneretaSmallRandomAsync() =>
            Task.Run(() =>
             {
                 var r = new Random();
                 int result = 0;
                 do { result = r.Next(); } while (result > 10);
                 return result;
             });

        public static void RunExo1()
        {
            Task<int> task = GeneretaSmallRandomAsync();
            Task<int> task2 = GeneretaSmallRandomAsync();

            Task.WaitAll(task, task2);
            Console.WriteLine($"1) {task.Result} + {task2.Result} = {task.Result + task2.Result}");
        }

        private static readonly HttpClient client = new HttpClient();
        public static async Task RunExo2()
        {
            var msg = await client.GetStringAsync("https://www.chucknorrisfacts.fr/facts/alea");
            Console.Write(msg);
            // @ chaine multiligne avec échappement
            await System.IO.File.WriteAllTextAsync(@"facts.html", msg);
        }

        public static Task<string[]> GetFilesAsync(string path)
        {
            return Task.Run(() => Directory.GetFiles(path));
        }
        public static async Task RunExo3(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No args");
                return;
            }
            string path = args[0];
            var files = Directory.GetFiles(path);
            Console.WriteLine(String.Join("\n", files));
            Console.WriteLine(await GetFilesAsync(path));
        }

        public static void RunExo4()
        {
            int x = 0;
            var task1 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Before inc {x}");
                    x += 1;
                    Console.WriteLine($"After inc {x}");
                }
            });

            var task2 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Before dec {x}");
                    x -= 1;
                    Console.WriteLine($"After dec {x}");
                }
            });

            Task.WaitAll(task1, task2);

            Console.WriteLine($"x => {x}");
        }

        public static void RunExo5()
        {
            int x = 0;
            // 20, 5, 30, 49...
            Parallel.For(0, 50, (i, state) =>
            {
                Console.WriteLine($"i => {i}");
                if (i >= 25)
                {
                    Console.WriteLine($"Before inc {x}");
                    x += 1;
                    Console.WriteLine($"After inc {x}");
                }
                else
                {
                    Console.WriteLine($"Before dec {x}");
                    x -= 1;
                    Console.WriteLine($"After dec {x}");
                }
            });
            Console.WriteLine($"x => {x}");
        }
    }
}