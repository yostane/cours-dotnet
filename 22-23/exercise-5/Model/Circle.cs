record Circle(double Radius)
{
    public double Area { get => Radius * Radius * Math.Pi; }
    public double Circumference { get => Diameter * Math.Pi; }
    public double Diameter { get => Radius * 2; }
}