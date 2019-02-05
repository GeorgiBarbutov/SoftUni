using System;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            while(true)
            {
                string command = Console.ReadLine();

                if(command == "end")
                {
                    break;
                }

                Func<int[], int[]> modifier = CreateModifier(command);

                numbers = modifier(numbers);
            }
        }

        private static Func<int[], int[]> CreateModifier(string command)
        {
            if (command == "add")
            {
                return x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] += 1;
                    }

                    return x;
                };
            }

            else if (command == "subtract")
            {
                return x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] -= 1;
                    }

                    return x;
                };
            }

            else if(command == "multiply")
            {
                return x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] *= 2;
                    }

                    return x;
                };
            }

            else if(command == "print")
            {
                return x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        Console.Write(x[i] + " ");
                    }
                    Console.WriteLine();

                    return x;
                };
            }

            else
            {
                return x => x;
            }
        }
    }
}
