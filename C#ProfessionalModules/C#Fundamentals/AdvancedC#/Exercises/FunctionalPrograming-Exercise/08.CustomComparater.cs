using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            Func<int, bool> isEven = x => x % 2 == 0;
            Func<int, bool> isOdd = x => x % 2 == 1 || x % 2 == -1;

            foreach (var number in numbers)
            {
                if(isEven(number))
                {
                    evenNumbers.Add(number);
                }
                else if(isOdd(number))
                {
                    oddNumbers.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", evenNumbers.OrderBy(x => x).ToArray()) + " " + String.Join(" ", oddNumbers.OrderBy(x => x).ToArray()));
        }
    }
}
