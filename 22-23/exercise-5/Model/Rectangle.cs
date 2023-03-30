record Rectangle(double Width, double Height) : Shape
{
    override public double Area { get => Width * Height; }
    override public double Circumference { get => (Width + Height) * 2; }
}