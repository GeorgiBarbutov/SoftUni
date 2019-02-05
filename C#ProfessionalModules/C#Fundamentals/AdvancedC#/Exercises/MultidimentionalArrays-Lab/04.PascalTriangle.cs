using System;

namespace Multidimensional_Arrays___Lab
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(1);
            }
            else if (n == 2)
            {
                Console.WriteLine(1);
                Console.WriteLine(1 + " " + 1);
            }
            else
            {
                long[][] triangle = new long[n][];

                triangle[0] = new long[] { 1 };
                triangle[1] = new long[] { 1, 1 };

                Console.WriteLine(1);
                Console.WriteLine(1 + " " + 1);

                for (int i = 2; i < n; i++)
                {
                    triangle[i] = new long[i + 1];

                    triangle[i][0] = 1;

                    for (int j = 1; j < i; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }

                    triangle[i][i] = 1;

                    Console.WriteLine(String.Join(" ", triangle[i]));
                }
            }
        }
    }
}
