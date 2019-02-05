using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Point topCorner = new Point(coordinates[0], coordinates[1]);
        Point bottomCorner = new Point(coordinates[2], coordinates[3]);

        Rectangle rectangle = new Rectangle(topCorner, bottomCorner);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] pointCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point point = new Point(pointCoordinates[0], pointCoordinates[1]);

            Console.WriteLine(rectangle.Contains(point));
        }
    }
}

