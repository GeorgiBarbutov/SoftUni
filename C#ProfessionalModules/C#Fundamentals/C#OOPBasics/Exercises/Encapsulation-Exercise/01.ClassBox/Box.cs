using System;

public class Box
{
    private double Length { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }
    private double SurfaceArea { get; set; }
    private double LateralArea { get; set; }
    private double Volume { get; set; }

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

