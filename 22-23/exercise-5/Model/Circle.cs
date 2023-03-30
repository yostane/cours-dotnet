using System;
record Circle(double Radius) : Shape
{
    override public double Area { get => Radius * Radius * Math.PI; }
    override public double Circumference { get => Diameter * Math.PI; }
    public double Diameter { get => Radius * 2; }

    public static Circle operator +(Circle c1, Circle c2) => new Circle(c1.Radius + c2.Radius);
}