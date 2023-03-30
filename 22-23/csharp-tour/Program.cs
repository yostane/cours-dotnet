var mutableCircle1 = new ImmutableCircle(10, "green");
Console.WriteLine(mutableCircle1);

var mutableCircle2 = new ImmutableCircle(10, "green");
Console.WriteLine(mutableCircle1 == mutableCircle2);

Circle c1 = new(10, "yellow");
var c2 = new Circle(10, "yellow");
Console.WriteLine(c1 == c2);
Console.WriteLine($"c1: {c1}  -  c2: {c2}");

// propriétés en read only
// ToString et ==, != et Equals sont implémentés et comparent les propriétés une par une
record Circle(int Radius, string Color)
{
    public int Area { get => Radius * 2 * Math.PI; }
}


class ImmutableCircle
{
    public int Radius { get; }
    public string Color { get; }

    public ImmutableCircle(int radius, string color)
    {
        Radius = radius;
        Color = color;
    }

    public override string ToString() => $"radius: {Radius}. Color: {Color}";
    public static bool operator ==(ImmutableCircle m1, ImmutableCircle m2)
    {
        return m1.Radius == m2.Radius && m1.Color == m2.Color;
    }

    public static bool operator !=(ImmutableCircle m1, ImmutableCircle m2)
    {
        return !(m1 == m2);
    }
}