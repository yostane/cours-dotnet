using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

List<Shape> GenerateRandomShapes(int count)
{
    Random r = new();
    List<Shape> shapes = new();
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("Hello");
        if (r.Next(2) == 1)
        {
            shapes.Add(new Circle(r.Next(2, 20)));
        }
        else
        {
            shapes.Add(new Rectangle(r.Next(2, 20), r.Next(2, 20)));
        }
    }
    return shapes;
}

var shapes = GenerateRandomShapes(10);
Console.WriteLine(string.Join("\n", shapes));

// yield génère les éléments à la demande (et pas tout d'une coup)
IEnumerable<Shape> GenerateRandomShapes2(int count)
{
    Random r = new();
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("Hello yield");
        if (r.Next(2) == 1)
        {
            yield return new Circle(r.Next(2, 20));
        }
        else
        {
            yield return new Rectangle(r.Next(2, 20), r.Next(2, 20));
        }
    }
}
var yieldedShapes = GenerateRandomShapes2(10);
Console.WriteLine(string.Join("\n", yieldedShapes));

foreach (var shape in yieldedShapes)
{
    Console.WriteLine(shape);
}

// where, select, aggregate
IEnumerable<Shape> GenerateRandomShapesLinq(int count)
{
    Random r = new();
    return Enumerable.Range(0, count + 1).Select((_) =>
    {
        if (r.Next(2) == 1)
        {
            return new Circle(r.Next(2, 20)) as Shape;
        }
        else
        {
            return new Rectangle(r.Next(2, 20), r.Next(2, 20)) as Shape;
        }
    });
}

var shapesLinq = GenerateRandomShapesLinq(10);
Console.WriteLine(string.Join("\n", shapesLinq));

var q8_1 = new
{
    maxWidth = shapes.Where((shape) => shape is Rectangle)
                                .Select((shape) => shape as Rectangle)
                                .Max((rectangle) => rectangle?.Width),
    sumCircleArea = shapes.Where((shape) => shape is Circle)
                            .Select((shape) => shape as Circle)
                            .Sum((circle) => circle?.Area)
};
Console.WriteLine(q8_1);

// var q8_2 = shapes.Select((shape) =>
// {
//     if (shape is Circle c)
//     {
//         return new { maxWidth = 0, sumCircleArea = c.Area };
//     }
//     else if (shape is Rectangle r)
//     {
//         return new { maxWidth = r.Width, sumCircleArea = 0 };
//     }
// });

var q9 = shapes.Where((shape) => shape is Circle).Count();
Console.WriteLine(q9);

var q10 = shapes.Where((shape) => shape is Rectangle && shape.Area > 10).Count();
Console.WriteLine(q10);

var q11 = shapes.Where((shape) => shape is Circle).Average((s) => s.Circumference);
Console.WriteLine(q11);

var t1 = new Task(() =>
{
    Console.WriteLine("Hello async");
});