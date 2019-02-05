using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Box<string>> collectionOfBoxes = new List<Box<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);

            collectionOfBoxes.Add(box);
        }

        int[] indexesToSwap = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        collectionOfBoxes = Swaper<Box<string>>.Swap(indexesToSwap[0], indexesToSwap[1], collectionOfBoxes);

        foreach (var box in collectionOfBoxes)
        {
            Console.WriteLine(box);
        }
    }

    
}

