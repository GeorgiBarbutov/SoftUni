public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double wigth)
        : base()
    {
        Height = height;
        Width = wigth;
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override double CalculatePerimeter()
    {
        return (2 * this.Height) + (2 * this.Width);
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }
}

