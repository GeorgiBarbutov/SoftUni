using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class StackFibonacci
    {
        static void Ninth(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            Stack<long> fibonacciNumbers = new Stack<long>(new long[] {0, 1});

            for (int i = 0; i < input - 1; i++)
            {
                long nMinus1Number = fibonacciNumbers.Pop();
                long nMinus2Number = fibonacciNumbers.Peek();
                long nNumber = nMinus1Number + nMinus2Number;

                fibonacciNumbers.Push(nMinus1Number);
                fibonacciNumbers.Push(nNumber);
            }

            Console.WriteLine(fibonacciNumbers.Peek());
        }
    }
}
