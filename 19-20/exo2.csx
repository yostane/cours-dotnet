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
Console.WriteLine($" = {somme}");
// ! à faire, ne pas afficher le dernier +

/*
écrivez un programme permettant de générer aléatoirement
10 notes comprises entre 0 et 20. 
Le programme, renvoie le nombre de ces notes supérieures à la moyenne de la classe.
*/

Console.WriteLine("--------- notes > moyennes -------");
int[] notes = new int[10];
int moyenne = 0;
for (int i = 0; i < notes.Length; i++)
{
    notes[i] = r.Next(20);
    moyenne += notes[i];
    Console.WriteLine($"notes[{i}] -> {notes[i]}");
}
moyenne /= notes.Length;
Console.WriteLine($"Moyenne -> {moyenne}");
for (int i = 0; i < notes.Length; i++)
{
    if (notes[i] > moyenne)
    {
        Console.WriteLine($"note {i} -> {notes[i]}");
    }
}
Console.WriteLine("--------- FIN notes > moyennes -------");


/*
Ecrire une fonction isPalindrome(string) qui permet de dire si une chaine de caractères est un palindrome
par exemple: isPalindrome("toto") -> false (-> toto != <- otot)
isPalindrome("totot") -> true
! Sans utiliser de fonction reverse
*/

Console.WriteLine("--------- Palindrome -------");
string palInput = "abcd";
// solution 1
string palReverse = "";
// 0 -> length: a, b, c, d
// length - 1 -> -1: d, c, b, a
// parcours inverse 1
for (int i = palInput.Length; i > 0; i--)
{
    Console.Write($"{i}: ");
    Console.WriteLine($"palInput[{i - 1}] -> {palInput[i - 1]}");
}
// parcours inverse 2
for (int i = palInput.Length - 1; i >= 0; i--)
{
    Console.Write($"{i}: ");
    Console.WriteLine($"palInput[{i}] -> {palInput[i]}");
    palReverse += palInput[i];
}
Console.WriteLine($"Reverse -> {palReverse}");

Console.Write(palInput);
if (palReverse == palInput)
{
    Console.WriteLine($" est un palindrome");
}
else
{
    Console.WriteLine($" n'est pas un palindrome");
}

Console.WriteLine("--------- Palindrome optimal -------");

string palOptimalInput = "43211t1234";
Console.WriteLine(palOptimalInput);
// Le nombre d'itérations correspond au nombres de test minimal
int i = 0;
for (i = 0; i < palOptimalInput.Length / 2; i++)
{
    Console.WriteLine($"{i}, {palOptimalInput.Length - i - 1}");
    if (palOptimalInput[i] == palOptimalInput[palOptimalInput.Length - i - 1])
    {
        Console.WriteLine($"Kifkif");
    }
    else
    {
        Console.WriteLine($"Pas kifkif");
        break;
    }
}
Console.WriteLine($"i=> {i}, palOptimalInput.Length / 2 => {palOptimalInput.Length / 2}");
Console.WriteLine($"{i == palOptimalInput.Length / 2}");

Console.WriteLine("--------- Fin palindrome -------");

/*
Ecrire une fonction isPalindrome(int) qui permet de dire si une entier est un palindrome
isPalindrome(1234) -> false
isPalindrome(12321) -> true
! Sans utiliser de fonction reverse
*/
Console.WriteLine("--------- Palindrome int -------");

int palInt = 1234321;
Console.WriteLine($"palInt {palInt}");
Console.WriteLine($"nb chiffres {(int)Math.Log10(palInt) + 1}");

// Console.WriteLine($"{palInt / 10}");
// Console.WriteLine($"{palInt / 10 / 10}");
// Console.WriteLine($"{palInt / 10 / 10 / 10}");
// Console.WriteLine($"{palInt / 10 / 10 / 10 / 10}");
// Console.WriteLine($"{palInt / 10 / 10 / 10 / 10 / 10}");

int GetNbDigits(int input)
{
    int k = 0;
    for (k = 0; input > 0; k++)
    {
        input /= 10;
    }
    return k == 0 ? 1 : k;
}

int GetDigitAtIndex(int input, int index)
{
    int originalIndex = index;
    int lastIndex = GetNbDigits(input) - 1;
    index = lastIndex - index; // pour aller de g à d

    if (index < 0 || index > lastIndex)
    {
        throw new IndexOutOfRangeException($"Indice {originalIndex} incorrect!");
    }

    int div = input / (int)Math.Pow(10, index);
    return div % 10;
}

int nbDigits = GetNbDigits(palInt);
Console.WriteLine($"nb chiffres avec une boucle: {nbDigits}");

// Le nombre d'itérations correspond au nombres de test minimal
int j = 0;
for (j = 0; j < nbDigits / 2; j++)
{
    int rightIndex = nbDigits - j - 1;
    Console.WriteLine($"{j}, {rightIndex}");
    if (GetDigitAtIndex(palInt, j) == GetDigitAtIndex(palInt, rightIndex))
    {
        Console.WriteLine($"Kifkif");
    }
    else
    {
        Console.WriteLine($"Pas kifkif");
        break;
    }
}
Console.WriteLine($"i=> {j}, nbdigits / 2 => {nbDigits / 2}");
Console.WriteLine($"{j == nbDigits / 2}");

Console.WriteLine("--------- Fin palindrome int -------");
