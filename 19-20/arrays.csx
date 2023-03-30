int[] prices = { 10, 200, 1000 };

foreach (int price in prices)
{
  Console.Write($"{price} - ");
}
Console.WriteLine();
Console.WriteLine($"Length: {prices.Length}. {prices.Last()}");

// rectangular array (tableau rectangulaire)
double[,] matrix4 = {
  {1, 2, 4},
  {10, 29, 41},
  {13, 22, 41},
  {9, 2, 8}
};
Console.WriteLine(matrix4);
foreach (var item in matrix4)
{
  Console.WriteLine(item);
}

// trouver le maximum de la matrice
for (int i = 0; i < matrix4.GetLength(0); i++)
{
  for (int j = 0; j < matrix4.GetLength(1); j++)
  {
    Console.WriteLine($"matrix4[{i}, {j}] => {matrix4[i, j]}");
  }
}

// sparse array (tableau éparse)
int[][] tab = new int[3][];
tab[0] = new int[2];
tab[0][0] = 3;
tab[0][1] = 6;
tab[1] = new int[4];
tab[1][0] = 3;
tab[1][1] = 6;
tab[1][2] = 1;
tab[1][3] = -3;
tab[2] = new int[2];
tab[2][0] = -3;
tab[2][1] = -6;
Console.WriteLine("tab");
for (int i = 0; i < tab.Length; i++)
{
  for (int j = 0; j < tab[i].Length; j++)
  {
    Console.WriteLine($"matrix4[{i}][{j}] => {tab[i][j]}");
  }
}