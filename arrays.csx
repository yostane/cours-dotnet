int[] prices = { 10, 200, 1000 };

foreach (int price in prices)
{
  Console.Write($"{price} - ");
}
Console.WriteLine();
Console.WriteLine($"Length: {prices.Length}. {prices.Last()}");

double[,] matrix4 = {
  {1, 2, 4},
  {10, 29, 41},
  {13, 22, 41},
  {9, 2, 8}
};
Console.WriteLine(matrix4);

// trouver le maximum de la matrice