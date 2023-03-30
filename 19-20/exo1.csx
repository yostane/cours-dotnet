/* Ectire un script csx qui génère 3 entier aléatoires 
au clavier et les affiche dans l'ordre croissant */

var r = new Random();
var a = r.Next(100);
var b = r.Next(100);
var c = r.Next(100);
Console.WriteLine($"a => {a}, b => {b}, c => {c}");
if (a > b)
{
  if (b > c)
  {
    Console.WriteLine($"{c}, {b}, {a}");
  }
  else if (a > c) // a > b et c > b
  {
    Console.WriteLine($"{b}, {c}, {a}");
  }
  else
  {
    Console.WriteLine($"{b}, {a}, {c}");
  }
}
else
{
  if (a > c) // b >= a et a > c
  {
    Console.WriteLine($"{c}, {a}, {b}");
  }
  else if (b > c) // b >= a et c >= a
  {
    Console.WriteLine($"{a}, {c}, {b}");
  }
  else // b >= a et c >= a et b <= c
  {
    Console.WriteLine($"{a}, {b}, {c}");
  }
}

/* Ecrire un programme qui génère des nombre alétoires
et s'arrete quand il aura généré le premier nombre 
une deuxième fois*/
Console.WriteLine("partie 2");
var r2 = new Random();
var exo2Val1 = r2.Next(5);
while (exo2Val1 != r.Next(5)) { }
Console.WriteLine("Fin partie 2");


/*Ecrire un programme qui génère un nombre de départ entre 0 et 9, 
et qui ensuite écrit la table de multiplication de ce nombre, 
présentée comme suit (cas où l'utilisateur entre le nombre 7) :
Table de 7 :
7 x 1 = 7
7 x 2 = 14
7 x 3 = 21
…
7 x 10 = 70
*/
var r3 = new Random();
var nb = r3.Next(9);
for (int i = 0; i <= 10; i++)
{
  Console.WriteLine($"{nb} X {i} = {nb * i}");
}
