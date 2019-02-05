using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class MaximumElement
    {
        static void Third(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine().Split(' ');

                if(query[0] == "1")
                {
                    numbers.Push(int.Parse(query[1]));

                    if(maxNumbers.Count == 0)
                    {
                        maxNumbers.Push(int.Parse(query[1]));
                    }
                    else
                    {
                        if(int.Parse(query[1]) > maxNumbers.Peek())
                        {
                            maxNumbers.Push(int.Parse(query[1]));
                        }
                    }
                }
                else if(query[0] == "2")
                {
                    int removedNumber = numbers.Pop();
                    
                    if(maxNumbers.Peek() == removedNumber)
                    {
                        maxNumbers.Pop();
                    }
                }
                else if(query[0] == "3")
                {
                    Console.WriteLine(maxNumbers.Peek());
                }
            }
        }
    }
}
