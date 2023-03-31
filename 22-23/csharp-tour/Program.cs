var mutableCircle1 = new ImmutableCircle(10, "green");
Console.WriteLine(mutableCircle1);

var mutableCircle2 = new ImmutableCircle(10, "green");
Console.WriteLine(mutableCircle1 == mutableCircle2);

Circle c1 = new(10, "yellow");
var c2 = new Circle(10, "yellow");
Console.WriteLine(c1 == c2);
Console.WriteLine($"c1: {c1}  -  c2: {c2}");


int sum(int[] numbers)
{
    return numbers.Sum();
}
sum(new int[] { 1, 2, 3, 4 });

int sumParams(params int[] numbers)
{
    return numbers.Sum();
}
sumParams(1, 2, 3, 4); // => new int[]{1, 2, 3, 4}

// propriétés en read only
// ToString et ==, != et Equals sont implémentés et comparent les propriétés une par une
record Circle(int Radius, string Color)
{
    public int Area { get => (int)(Radius * 2 * Math.PI); }
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

    public override bool Equals(object? obj)
    {
        if (obj is ImmutableCircle c)
        {
            return this == c;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Radius, Color);
    }
}