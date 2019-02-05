using System;

public class Box
{

    private double length;
    private double width;
    private double height;
    private double SurfaceArea;
    private double LateralArea;
    private double Volume;

    private double Height
    {
        get { return height; }

        set
        {
            if (value <= 0)
                throw new ArgumentException("Height cannot be zero or negative.");

            height = value;
        }
    }

    private double Length
    {
        get { return length; }

        set
        {
            if (value <= 0)
                throw new ArgumentException("Length cannot be zero or negative.");

            length = value;
        }
    }

    private double Width
    {
        get { return width; }

        set
        {
            if (value <= 0)
                throw new ArgumentException("Width cannot be zero or negative.");

            width = value;
        }
    }


    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;

        CalculateSurfaceArea();
        CalculateLateralArea();
        CalculateVolume();
    }

    private void CalculateVolume()
    {
        Volume = Length * Width * Height;
    }

    private void CalculateLateralArea()
    {
        LateralArea = (2 * Length * Height) + (2 * Width * Height);
    }

    private void CalculateSurfaceArea()
    {
        SurfaceArea = (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }

    public void Print()
    {
        Console.WriteLine($"Surface Area - {SurfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {LateralArea:f2}");
        Console.WriteLine($"Volume - {Volume:f2}");
    }
}

