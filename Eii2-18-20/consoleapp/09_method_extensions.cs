using System.Linq;
using System;
namespace Csharp
{

    // Sans les extesnions
    static class StringUtils
    {
        public static bool IsPalindrome(string s) =>
            s.Reverse().Aggregate("", (acc, c) => acc + c) == s;
    }

    static class DemoExtensions
    {
        public static void ChangePosition(this YuGiOhCard card)
        {
            Console.WriteLine($"Changing position of {card.Name}");
        }

        public static bool IsPalindrome(this string s) =>
            s.Reverse().Aggregate("", (acc, c) => acc + c) == s;

        public static void Run()
        {
            var card = new YuGiOhCard("Magicien sombre", 200);
            card.ChangePosition();

            Console.WriteLine("SAVAS".IsPalindrome());
            string s = "LABASS";
            Console.WriteLine(s.IsPalindrome());

            var result = StringUtils.IsPalindrome(s);
            Console.WriteLine(result);
        }
    }
}