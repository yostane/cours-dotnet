void SayPika()
{
  Console.WriteLine("Pika");
}

int Add(int a, int b)
{
  return a + b;
}

// One line function ou fonction expression
int Multiply(int a, int b) => a * b;

SayPika();
Console.WriteLine(Add(3, 5));
Console.WriteLine(Multiply(3, 5));