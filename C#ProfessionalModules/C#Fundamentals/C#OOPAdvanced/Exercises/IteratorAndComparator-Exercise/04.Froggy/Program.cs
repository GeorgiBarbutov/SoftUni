using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        Lake lake = new Lake(numbers);

        List<int> result = new List<int>(); 

        foreach (var stone in lake)
        {
            result.Add(stone);
        }

        Console.WriteLine(String.Join(", ", result));
    }
}

