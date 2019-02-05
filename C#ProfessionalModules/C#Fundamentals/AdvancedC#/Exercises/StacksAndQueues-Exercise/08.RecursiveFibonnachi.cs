using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class RecursiveFibonacci
    {
        static void Eight(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            Dictionary<long, long> knownNumbers = new Dictionary<long, long>();

            knownNumbers.Add(1, 1);
            knownNumbers.Add(2, 1);

            Console.WriteLine(getFibonacchi(input, knownNumbers));
        }

        private static long getFibonacchi(long input, Dictionary<long, long> knownNumbers)
        {
            if (knownNumbers.ContainsKey(input))
            {
                return knownNumbers[input];
            }
            else
            {
                long number = getFibonacchi(input - 1, knownNumbers) + getFibonacchi(input - 2, knownNumbers);
                knownNumbers.Add(input, number);

                return number;
            }
        }
    }
}
