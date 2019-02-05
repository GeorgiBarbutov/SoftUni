using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ICollection<string> collection = new List<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();           
            collection.Add(input);
        }

        string elementToCompare = Console.ReadLine();
        Box<string> box = new Box<string>(elementToCompare);

        Console.WriteLine(box.Count(collection, elementToCompare));
    }
}

