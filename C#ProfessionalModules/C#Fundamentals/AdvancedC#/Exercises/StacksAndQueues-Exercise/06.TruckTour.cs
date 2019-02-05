using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class TruckTour
    {
        static void Sixth(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                queue.Enqueue(pumps);
            }

            for (int currentStart = 0; currentStart < queue.Count; currentStart++)
            {
                int gasInTank = 0;
                int distanceToNextPump = 0;
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < queue.Count; pumpsPassed++)
                {
                    int[] currentPump = queue.Dequeue();
                    gasInTank = currentPump[0];
                    distanceToNextPump = currentPump[1];

                    fuel += gasInTank - distanceToNextPump;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(currentPump);
                    }
                }

                if(isSolution == true)
                {
                    Console.WriteLine(currentStart);
                    break;
                }
            }
        }
    }
}
