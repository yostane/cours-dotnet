using System.Linq;
using System;
using System.Collections.Generic;

namespace Csharp
{
    public class DemoControlFlow
    {
        public static void Run()
        {
            int x = new Random().Next(100);

            if (x > 50)
            {
                Console.WriteLine("Above");
            }
            else
            {
                Console.WriteLine("Below");
            }

            switch (x)
            {
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 50:
                    Console.WriteLine("Average");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            string s = "Zero";
            switch (s)
            {
                case "Zero":
                    Console.WriteLine("Zero");
                    break;
                case "Avergage":
                    Console.WriteLine("Average");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            int j = 10;
            while (j > 0)
            {
                Console.WriteLine(j);
                j -= 1;
            }

            foreach (char c in s)
            {
                Console.Write($"{c} - ");
            }
        }
    }
}