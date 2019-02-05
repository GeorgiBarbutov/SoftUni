using System;
using System.Collections.Generic;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class CalculateSequenceWithQueue
    {
        static void Fifth(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> fullQueue = new Queue<long>();

            fullQueue.Enqueue(n);

            long increment;
            Console.Write(n + " ");

            for (int i = 0; i < 16; i++)
            {
                increment = fullQueue.Dequeue();
  
                fullQueue.Enqueue(increment + 1);
                Console.Write((increment + 1) + " ");
                fullQueue.Enqueue(2 * increment + 1);
                Console.Write((2 * increment + 1) + " ");
                fullQueue.Enqueue(increment + 2);
                Console.Write((increment + 2) + " ");
            }

            increment = fullQueue.Dequeue();
            fullQueue.Enqueue(increment + 1);
            Console.Write((increment + 1));
        }
    }
}
