public class Rectangle
{
    public Point TopCorner { get; set; }
    public Point BottomCorner { get; set; }

    public Rectangle(Point topCorner, Point bottomCorner)
    {
        TopCorner = topCorner;
        BottomCorner = bottomCorner;
    }

    public bool Contains(Point point)
    {
        bool res =  TopCorner.X <= point.X
            && BottomCorner.X >= point.X
            && TopCorner.Y <= point.Y
            && BottomCorner.Y >= point.Y;

        return res;
    }
}

