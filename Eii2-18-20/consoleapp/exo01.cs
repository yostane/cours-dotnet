using System;
using System.Linq;
/* A faire avec LINQ tant que possible */

/* Soit une List<string>:
1- Afficher les chaines de caractère de longeur < 6
2- Afficher le nombre total de caractères dans toute la liste
3- Afficher les élements qui au contiennent 3 voyelles exactement
4- Afficher en majuscules le contenu de la liste
5- Trier par ordre alphabétique décroissant le contenu de la lsite
6- Afficher les éléments qui ne contiennent que des minuscules
7- Afficher les palindromes
8 part 1- Afficher en majuscules et trier par ordre alphabétique croissant les réultats de la questions 1
8 part 2- Afficher en majuscules et trier par ordre alphabétique croissant les réultats de la questions 3
9- Afficher un mot qui met à la suite la première lettre de chaque élément
9 part 2- Afficher un mot qui met à la suite la première lettre de chaque élément. Chaque élément vide sont remplacés par un espace
10- Mettre en commun et trier par order alphabétique les résultats des questions 1, 2 (convertir en String) et 3*/

using System.Collections.Generic;

namespace Csharp.Assignment
{
    public class Assignment01
    {


        public static void Run()
        {
            var l = new List<string>() { "Tintin", "Milou", "", "haddock", "SAVAS" };

            var l1 = l.Where(s => s.Length < 6);
            Console.WriteLine($"1- {String.Join(" - ", l1)}");

            var l2 = l.Select(s => s.Length).Aggregate((acc, item) => acc + item);
            var l2bis = l.Aggregate(0, (acc, item) => acc + item.Length);
            Console.WriteLine($"2- {String.Join(" - ", l2)} - {String.Join(" - ", l2bis)}");

            Func<string, bool> SatisfiesQ3 = s => s.Where(c => "aeiouAEIOU".IndexOf(c) > 0).Count() == 3;
            var l3 = l.Where(SatisfiesQ3).ToList();
            Console.WriteLine($"3- {String.Join(" - ", l3)}");

            Console.WriteLine($"4- {String.Join("-", l.Select(s => s.ToUpper()))}");


            Console.WriteLine($"5- {String.Join("-", l.OrderByDescending(s => s))}");
            Console.WriteLine($"Trier par nombre de chats- {String.Join("-", l.OrderByDescending(s => s.Length))}");

            Func<string, bool> SatisfiesQ6 = s => s.All(Char.IsLower);
            Console.WriteLine($"6- {String.Join("-", l.Where(SatisfiesQ6))}");
            var l6bis = l.Where(x => x.Equals(x.ToLower()));
            Console.WriteLine($"6- {String.Join("-", l6bis)}");

            var l7 = l.Where(s =>
            {
                var reverse = s.Reverse().Aggregate("", (acc, current) => acc + current);
                return s == reverse;
            });
            Console.WriteLine($"7- {String.Join("-", l7)}");

            Func<String, bool> SatisfaitQ7 = s => s == new string(s.Reverse().ToArray());
            var l7bis = l.Where(SatisfaitQ7);
            Console.WriteLine($"7- {String.Join(" - ", l7bis)}");

            Func<IEnumerable<string>, IEnumerable<string>> computeQ8 = l => l.Select(s => s.ToUpper()).OrderBy(s => s);
            IEnumerable<string> l8part1 = computeQ8(l1);
            Console.WriteLine($"8- {String.Join("-", l8part1)}");
            Console.WriteLine($"8- {String.Join("-", computeQ8(l3))}");

            string l9 = l.Where(s => s.Length > 0).Select(s => s[0]).Aggregate("", (acc, cuurent) => acc + cuurent);
            Console.WriteLine($"9- {l9}");

            string l9part2 = l.Select(s => s.Length > 0 ? s[0] : ' ').Aggregate("", (acc, cuurent) => acc + cuurent);
            Console.WriteLine($"9 part2- {l9part2}");

            var l10 = l1.Append(l2.ToString()).Union(l3).OrderBy(s => s);
            Console.WriteLine($"10 - {String.Join(", ", l10)}");
        }
    }
}