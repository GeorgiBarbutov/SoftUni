using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> MinFunction = x =>
            {
                int min = int.MaxValue;
                foreach (var number in x)
                {
                    if (min > number)
                    {
                        min = number;
                    }
                }
                return min;
            };


            Console.WriteLine(
                MinFunction(
                    Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray()));
        }
    }
}
