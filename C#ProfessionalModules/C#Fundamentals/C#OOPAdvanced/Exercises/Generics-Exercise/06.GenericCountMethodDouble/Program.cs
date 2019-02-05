using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ICollection<double> collection = new List<double>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());           
            collection.Add(input);
        }

        double elementToCompare = double.Parse(Console.ReadLine());
        Box<double> box = new Box<double>(elementToCompare);

        Console.WriteLine(box.Count(collection, elementToCompare));
    }
}

