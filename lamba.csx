void Compute(int a, int b, Action<int, int> f) // void f(int, int)
{
  f(a, b);
}
Action<int, int> g = (x, y) => Console.WriteLine(x - y);
Compute(3, 5, (x, y) =>
{
  Console.WriteLine(x - y);
});
Compute(5, 2, g);

void PrintResult(int a, int b, Func<int, int, string> f)
{
  Console.WriteLine(f(a, b));
}

PrintResult(5, 66, (x, y) => $"{x} / {y}");


