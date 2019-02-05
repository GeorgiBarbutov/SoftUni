using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_CSharp_Fundamentals_Labs
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int carCount = 0;

            Queue<string> queue = new Queue<string>();

            while(true)
            {
                if (command == "end")
                {
                    break;
                }
                else if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if(queue.Count == 0)
                        {
                            break;
                        }
                        string car = queue.Dequeue();

                        Console.WriteLine("{0} passed!", car);

                        carCount++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("{0} cars passed the crossroads.", carCount);
        }
    }
}
