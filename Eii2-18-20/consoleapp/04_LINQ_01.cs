using System.Linq;
using System;
using System.Collections.Generic;

namespace Csharp
{
    public class DemoLinq01
    {
        public static void Run()
        {
            var l = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }

            var l2 = new List<int>();
            foreach (var item in l)
            {
                if (item % 2 == 0)
                {
                    l2.Add(item * 2);
                }
            }

            // LINQ
            /**
                            
                if (item % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            */
            var l3 = l.Where(item => item % 2 == 0).Select(item => item * 2).ToList();

            Console.WriteLine(String.Join(" - ", l2));
        }
    }
}