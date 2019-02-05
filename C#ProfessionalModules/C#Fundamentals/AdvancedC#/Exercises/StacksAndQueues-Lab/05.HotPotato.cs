using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CSharp_Fundamentals_Labs
{
    class HotPotato
    {
		static void FifthExercise()
        {
            string[] names = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            int removeCount = 1;

			while(queue.Count != 1)
            {
				if(removeCount == n)
                {
                    string RemovedName = queue.Dequeue();
                    Console.WriteLine("Removed {0}", RemovedName);
                    removeCount = 0;
                }
                else
                {
                    string nameToSwitch = queue.Dequeue();
                    queue.Enqueue(nameToSwitch);
                }

                removeCount++;
            }

            Console.WriteLine("Last is {0}", queue.Dequeue());
        }
    }
}
