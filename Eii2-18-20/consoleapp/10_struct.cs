using System;
namespace Csharp
{
    struct Complex
    {
        double Real, Imaginary;

        override public string ToString() => $"{Real} + i{Imaginary}";

        public static void Run()
        {
            Complex c = new Complex();
            c.Real = 10;
            c.Imaginary = 20;
            Console.WriteLine(c);

            Console.WriteLine($"Before function {c}");
            AddValue(ref c, 20);
            Console.WriteLine($"After function {c}");
        }

        public static void AddValue(ref Complex c, int value)
        {
            c.Real += value;
            Console.WriteLine($"Inside function {c}");
        }
    };
}