using System;
namespace Csharp.Typing
{
    public class Demo
    {
        public static void showTypes()
        {
            // typage statique (type de la variable ne change pas)
            // typage explicite
            int i = 10;
            double j = 20.222;
            string s = "I am a string";
            bool test = true;
            bool test2 = (i == 11);
            // typage implicite
            var z = 30;

            Console.WriteLine("i: " + i);
            Console.WriteLine($"i: {i} - s: {s}. {z + i - 20}");
        }
    }
}