using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class ReverseStrings
    {
        static void First(string[] args)
        {
            string[] integers = Console.ReadLine().Split(' ');
            Stack<string> numbers = new Stack<string>(integers);

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
