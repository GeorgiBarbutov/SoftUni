using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class BasicStackOperations
    {
        static void Second(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int numberOfElementsToPush = int.Parse(input[0]);
            int numberOfElementsToPop = int.Parse(input[1]);
            string XElement = input[2];

            string[] elements = Console.ReadLine().Split(' ');

            Stack<string> numbers = new Stack<string>();

            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                numbers.Push(elements[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                numbers.Pop();
            }

            if(numbers.Contains(XElement))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
