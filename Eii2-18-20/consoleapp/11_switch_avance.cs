using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp
{
    public class DemoSwitchAvance
    {
        public static void Run()
        {
            int i = 63;
            switch (i)
            {
                case int n when n >= 100:
                    Console.WriteLine($"I am 100 or above: {n}");
                    break;
                case int n when n < 100 && n >= 50:
                    Console.WriteLine($"I am between 99 and 50: {n}");
                    break;
                case int n when n < 50:
                    Console.WriteLine($"I am less than 50: {n}");
                    break;
            }

            Console.WriteLine(Compute(new BouzeSpeakerRecorder()));
            Console.WriteLine(Compute(1));
        }

        public static string Compute(object o)
        {
            switch (o)
            {
                case ISpeaker s:
                    s.Speak();
                    return "Speaker";
                case string s:
                    return s;
                default:
                    return "unknown";
            }
        }
    }
}