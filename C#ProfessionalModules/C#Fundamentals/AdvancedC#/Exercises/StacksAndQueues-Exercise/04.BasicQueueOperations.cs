using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class BasicAueueOperations
    {
        static void Fourth(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int numberOfElementsToPush = int.Parse(input[0]);
            int numberOfElementsToPop = int.Parse(input[1]);
            string XElement = input[2];

            string[] elements = Console.ReadLine().Split(' ');

            Queue<string> numbers = new Queue<string>();

            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                numbers.Enqueue(elements[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(XElement))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
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
