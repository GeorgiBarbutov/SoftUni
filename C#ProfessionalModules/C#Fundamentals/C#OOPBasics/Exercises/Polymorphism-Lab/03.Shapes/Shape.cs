public abstract class Shape
{
    public Shape()
    {

    }

    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();

    public virtual string Draw()
    {
        return "Drawing ";
    }
}

