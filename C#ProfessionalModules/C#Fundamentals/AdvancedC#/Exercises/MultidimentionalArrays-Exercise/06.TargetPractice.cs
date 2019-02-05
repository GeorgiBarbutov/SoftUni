using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rowsAndColums[0];
            int colums = rowsAndColums[1];

            string snakesName = Console.ReadLine();

            int[] impactParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int impactRow = impactParameters[0];
            int impactColumn = impactParameters[1];
            int impactRadius = impactParameters[2];

            char[][] matrix = new char[rows][];

            CreateMatrix(matrix, rows, colums, snakesName);

            DestroyCells(matrix, impactRow, impactColumn, impactRadius);

            MoveCells(matrix, rows, colums);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveCells(char[][] matrix, int rows, int colums)
        {
            for (int j = 0; j < colums; j++)
            {
                for (int cycleTurns = 0; cycleTurns < rows; cycleTurns++)
                {
                    for (int i = rows - 1; i > 0; i--)
                    {
                        if (matrix[i][j] == ' ' && matrix[i - 1][j] != ' ')
                        {
                            char temp = matrix[i][j];
                            matrix[i][j] = matrix[i - 1][j];
                            matrix[i - 1][j] = temp;
                        }
                    }
                }
            }
        }

        private static void DestroyCells(char[][] matrix, int impactRow, int impactColumn, int impactRadius)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (Math.Sqrt((i - impactRow) * (i - impactRow) + (j - impactColumn) * (j - impactColumn)) <= impactRadius)
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }
        }

        private static void CreateMatrix(char[][] matrix, int rows, int colums, string snakesName)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[colums];
            }

            int snakesNameCounter = 0;

            for (int i = matrix.Length - 1; i >= 0;)
            {
                for (int j = matrix[i].Length - 1; j >= 0; j--)
                {
                    matrix[i][j] = snakesName[snakesNameCounter];
                    snakesNameCounter++;

                    if (snakesNameCounter > snakesName.Length - 1)
                    {
                        snakesNameCounter = 0;
                    }
                }

                i--;

                if (i < 0)
                {
                    break;
                }

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = snakesName[snakesNameCounter];
                    snakesNameCounter++;

                    if (snakesNameCounter > snakesName.Length - 1)
                    {
                        snakesNameCounter = 0;
                    }
                }

                i--;
            }
        }
    }
}
