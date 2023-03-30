for (int i = 0; i < 10; i++)
{

}

int i = 10;
while (i > 0)
{
  Console.WriteLine(i);
  i -= 1;
}

var s = "Please loop me";
foreach (var c in s)
{
  Console.Write($"{c} - ");
}