using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int n = input[0];
        int m = input[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < n; i++)
        {
            string[] rectangleInput = Console.ReadLine().Split(' ');

            string rectangleId = rectangleInput[0];
            double rectangleWidth = double.Parse(rectangleInput[1]);
            double rectangleHeight = double.Parse(rectangleInput[2]);
            double rectangleX = double.Parse(rectangleInput[3]);
            double rectangleY = double.Parse(rectangleInput[4]);

            Rectangle rectangle = new Rectangle(rectangleId, rectangleWidth, rectangleHeight, rectangleX, rectangleY);

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < m; i++)
        {
            string[] rectanglesToCompare = Console.ReadLine().Split(' ');

            Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == rectanglesToCompare[0]);
            Rectangle secondRectangle = rectangles.FirstOrDefault(x => x.Id == rectanglesToCompare[1]);

            bool result = firstRectangle.Intersects(secondRectangle);

            Console.WriteLine(result.ToString().ToLower());
        }
    }
}

