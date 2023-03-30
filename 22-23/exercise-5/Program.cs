using System;

Circle c1 = new(10);
Circle c2 = new(10);

//ToString() est implicitement appelé dans certain cas
Console.WriteLine($"c1: {c1.ToString()}, c2: {c2}");
// == peut être surchargé en c#. Record implémente ==, Equals et != qui compare les prorpiété et non les adresses mémoire
Console.WriteLine($"c1 == c2 ? {c1 == c2}, Equals ? {c1.Equals(c2)}, != {c1 != c2}");
Console.WriteLine($"c1 + c2 : {c1 + c2}");

void PrintShapeInfo(Shape shape)
{
    switch (shape)
    {
        case Circle c when c.Radius > 10:
            Console.WriteLine($"Circle avec un rayon > 10 {c.Diameter}");
            break;
        case Rectangle r:
            Console.WriteLine($"Rectangle {r.Width}");
            break;
        default:
            Console.WriteLine("Autre cas");
            break;
    }
}

PrintShapeInfo(c1);
PrintShapeInfo(new Rectangle(5, 20));
