using System;
using System.Collections.Generic;

namespace Csharp
{
    public class DemoLambda
    {
        // Action -> pas de retour (void)
        // Func -> retourne une valeur
        // Type de fonctions (Action ou Func)<type des arguments, type de retour (que pour les Func)>
        public static void ApplyActionToParam(string s, Action<string> f)
        {
            //ssdffsdfdsf
            f(s);
            //sdfsdf
        }

        public static List<int> DoSomething(string s, char c, bool b) => null;

        public static void PrintToConsole(string s) => Console.WriteLine(s);
        public static int GetCount(string s) => s.Length;
        public static void PrintToConsoleNoParam() => Console.WriteLine("Vive la solitude");

        public static void Run()
        {
            Action<string, Action<string>> f1 = ApplyActionToParam;
            Func<string, char, bool, List<int>> f2 = DoSomething;

            Action<string> f = PrintToConsole;
            var g = f;
            f("Appel de f");
            g("Appel de g");

            // définition en ligne ou avec une lambda ou avec une fonction anonyme
            Action<string> h = s =>
            {
                Console.WriteLine($"h: lambda {s}");
            };
            h("Appel de h");

            Func<string, char, bool, List<int>> f3 = (p1, p2, p3) => new List<int>();

            Action action = PrintToConsoleNoParam;
            action();
            PrintToConsoleNoParam();

            Func<string, int> myFunc = GetCount;
            Console.WriteLine(myFunc("1, 2, 3 soleil"));

            ApplyActionToParam("test1", PrintToConsole);
            ApplyActionToParam("test2", h);
            // ApplyActionToParam("test2", myFunc); // erreur
            ApplyActionToParam("test3", s => Console.WriteLine($"inline : {s}"));
        }
    }
}