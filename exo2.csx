// Dans la suite, la valeur max des nombres aléatoire est de 10

/*Ecrire un programme qui génère un tableau 2D éparse de 4 lignes.
Pour chaque ligne, le nombre de colonnes est un nombre 
aléatoire.
Remplir cette matrice par des nombres aléatoires */

int[][] t1 = new int[4][];
var r = new Random();
for (int i = 0; i < t1.Length; i++)
{
  t1[i] = new int[r.Next(10)];
}

for (int i = 0; i < t1.Length; i++)
{
  for (int j = 0; j < t1[i].Length; j++)
  {
    t1[i][j] = r.Next(10);
  }
}

/*Afficher cette matrice comme sur excel
  A B C...
1| 4 6...
2| 5  4..
3| -2 5...*/

Console.Write("l\\c".PadRight(4));
for (char i = 'A'; i <= 'Z'; i++)
{
  Console.Write(i.ToString().PadRight(4));
}
Console.WriteLine();
for (int i = 0; i < t1.Length; i++)
{
  Console.Write($"{i}|".PadRight(4));
  for (int j = 0; j < t1[i].Length; j++)
  {
    Console.Write(t1[i][j].ToString().PadRight(4));
  }
  Console.WriteLine();
}

/*Ecrire un programme qui génère deux tableau 
de tailles aléatoires et de contenus aléatoire.

Calcule le schtroumpf des deux tableaux et afficher le détail.
Pour calculer le schtroumpf, 
il faut multiplier chaque élément du tableau 1 
par chaque élément du tableau 2, et additionner le tout.
Par exemple si l'on a : [4, 8, 7, 12] et [3, 6], 
le programme va afficher:

Le Schtroumpf sera :
3 x 4 + 3 x 8 + 3 x 7 + 3 x 12 + 6 x 4 + 6 x 8 + 6 x 7 + 6 x 12 = 279
*/

int[] s1 = new int[r.Next(10)];
int[] s2 = new int[r.Next(10)];
for (int i = 0; i < s1.Length; i++)
{
  s1[i] = r.Next(10);
}
for (int i = 0; i < s2.Length; i++)
{
  s2[i] = r.Next(10);
}

int somme = 0;
for (int i = 0; i < s1.Length; i++)
{
  for (int j = 0; j < s2.Length; j++)
  {
    somme += s1[i] * s2[j];
    Console.Write($"{s1[i]} x {s2[j]} ");
    if (!(i + 1 == s1.Length && j + 1 == s2.Length))
    {
      Console.Write($"+ ");
    }
  }
}
Console.Write($" = {somme}");
// ! à faire, ne pas afficher le dernier +

/*
écrivez un programme permettant de générer aléatoirement
10 notes comprises entre 0 et 20. 
Le programme, renvoie le nombre de ces notes supérieures à la moyenne de la classe.
*/


/*
Ecrire une fonction isPalindrome(string) qui permet de dire si une chaine de caractères est un palindrome
par exemple: isPalindrome("toto") -> false
isPalindrome("totot") -> true
! Sans utiliser de fonction reverse
*/

/*
Ecrire une fonction isPalindrome(int) qui permet de dire si une entier est un palindrome
isPalindrome(1234) -> false
isPalindrome(12321) -> true
! Sans utiliser de fonction reverse
*/

