using System;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ');

            Func<string, int, bool> checkName = (x, y) =>
            {
                int sum = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    sum += (int)x[i];
                }

                if(sum >= y)
                {
                    return true;
                }

                return false;
            };

            Func<Func<string, int, bool>, string[], int, string> findFirstName = (func, allNames, sumToHave) =>
            {
                bool hasHigherSum = false;

                foreach (var name in allNames)
                {
                    hasHigherSum = func(name, sumToHave);

                    if (hasHigherSum)
                    {
                        return name;
                    }
                }

                return "";
            };

            Console.WriteLine(findFirstName(checkName, names, n));
        }
    }
}
