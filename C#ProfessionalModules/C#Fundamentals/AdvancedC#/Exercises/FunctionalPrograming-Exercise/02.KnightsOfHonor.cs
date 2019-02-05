using System;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine("Sir " + x);

            string[] names = Console.ReadLine().Split(' ');

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
