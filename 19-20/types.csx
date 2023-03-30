int i = 0;
string s = "Hello";
float f = 1.3F;
double d = 3.0;
bool b = true;
var k = 20; // typage implicite
//k = "toto"; // erreur

string chaine = $"un entier {i}. Une autre var {s}";
Console.WriteLine(chaine);
Console.WriteLine("un entier {i}. Une autre var {s}");
Console.WriteLine($"Expression {i + 3}");
Console.WriteLine($"Expression {i = 9}");