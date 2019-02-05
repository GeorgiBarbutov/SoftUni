using System;
using System.Linq;

namespace Functional_Programming___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            Console.WriteLine(String.Join(", ", numbers.Where(n => n % 2 == 0).OrderBy(x => x)));
        }
    }
}

