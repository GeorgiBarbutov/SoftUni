using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            PrintRow(n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            PrintRow(n, i);           
        }
    }

    private static void PrintRow(int n, int iterations)
    {
        Console.Write(new string(' ', n - iterations));
        for (int j = 0; j < iterations; j++)
        {
            Console.Write("* ");
        }

        Console.WriteLine();
    }
}

