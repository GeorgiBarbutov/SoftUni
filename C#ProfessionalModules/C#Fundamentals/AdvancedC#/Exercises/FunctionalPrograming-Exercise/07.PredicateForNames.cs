using System;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ');

            Func<string, bool> filter = CreateFilter(n);

            foreach (var name in names)
            {
                if(filter(name))
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static Func<string, bool> CreateFilter(int n)
        {
            return x => x.Length <= n;
        }
    }
}
