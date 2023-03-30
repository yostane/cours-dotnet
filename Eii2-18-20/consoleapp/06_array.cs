using System.Linq;
using System;
using System.Collections.Generic;

namespace Csharp
{
    public class DemoArray
    {
        public static void Run()
        {
            int[] prices = { 10, 200, 1000 };

            foreach (int price in prices)
            {
                Console.Write($"{price} - ");
            }
            Console.WriteLine();
            Console.WriteLine($"Length: {prices.Length}. {prices.Last()}");
            prices.Append(9999);
            Console.WriteLine($"Length: {prices.Length}. Le prix incroyable de: {prices.Last()}");

            List<int> l = prices.ToList();
            int[] t = l.ToArray();
        }
    }
}