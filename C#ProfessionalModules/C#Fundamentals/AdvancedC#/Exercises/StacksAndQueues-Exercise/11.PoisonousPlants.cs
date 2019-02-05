using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class PoisonousPlants
    {
        static void Eleventh(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(plants);
            List<int> plantsForNextDay = new List<int>();

            int days = 0;

            while(true)
            {
                days++;

                int leftPlant = queue.Dequeue();
                plantsForNextDay.Add(leftPlant);

                int queueCountBeforeTheDay = queue.Count + 1;

                for (int i = 0; i < queueCountBeforeTheDay - 1; i++)
                {
                    int rightPlant = queue.Dequeue();

                    if(rightPlant <= leftPlant)
                    {
                        leftPlant = rightPlant;
                        plantsForNextDay.Add(leftPlant);
                    }
                    else
                    {
                        leftPlant = rightPlant;
                    }
                }

                int queueCountAfterDay = plantsForNextDay.Count;

                if(queueCountBeforeTheDay == queueCountAfterDay)
                {
                    break;
                }

                foreach (var plant in plantsForNextDay)
                {
                    queue.Enqueue(plant);
                }

                plantsForNextDay.Clear();
            }

            Console.WriteLine(days - 1);
        }
    }
}
