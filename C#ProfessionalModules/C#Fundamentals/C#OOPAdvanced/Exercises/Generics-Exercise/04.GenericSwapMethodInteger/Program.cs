using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Box<int>> collectionOfBoxes = new List<Box<int>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(input);

            collectionOfBoxes.Add(box);
        }

        int[] indexesToSwap = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        collectionOfBoxes = Swaper<Box<int>>.Swap(indexesToSwap[0], indexesToSwap[1], collectionOfBoxes);

        foreach (var box in collectionOfBoxes)
        {
            Console.WriteLine(box);
        }
    }

    
}

