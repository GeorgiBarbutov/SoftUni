public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        Id = id;
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public bool Intersects(Rectangle secondRectangle)
    {
        if (X + Width < secondRectangle.X || secondRectangle.X + secondRectangle.Width < X || Y + Height < secondRectangle.Y || secondRectangle.Y + secondRectangle.Height < Y)
        {
            return false;
        }

        return true;
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
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

    public double X
    {
        get { return x; }
        private set { x = value; }
    }

    public double Y
    {
        get { return y; }
        private set { y = value; }
    }
}

