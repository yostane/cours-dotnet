int x = new Random().Next(100);

if (x > 50)
{
  Console.WriteLine("Above");
}
else
{
  Console.WriteLine("Below");
}

switch (x)
{
  case 0:
    Console.WriteLine("Zero");
    break;
  case 50:
    Console.WriteLine("Average");
    break;
  default:
    Console.WriteLine("default");
    break;
}