using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class RubikMatrix
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            int rows = rowsAndColums[0];
            int colums = rowsAndColums[1];

            int[][] matrix = new int[rows][];
            int[][] fixedMatrix = new int[rows][];

            FillInMatrix(matrix, rows, colums, fixedMatrix);

            ShuffleMatrix(matrix, n);

            RearangeTheMatrix(matrix, fixedMatrix);
        }

        private static void RearangeTheMatrix(int[][] matrix, int[][] fixedMatrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int currentNumber = matrix[i][j];
                    int correctNumber = fixedMatrix[i][j];

                    if (currentNumber == correctNumber)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int correctNumberRowIndex = 0;
                        int correctNumberColumnIndex = 0;
                        bool correctNumberIsFound = false;

                        for (int k = 0; k < matrix.Length; k++)
                        {
                            for (int l = 0; l < matrix[k].Length; l++)
                            {
                                if (matrix[k][l] == correctNumber)
                                {
                                    correctNumberRowIndex = k;
                                    correctNumberColumnIndex = l;
                                    correctNumberIsFound = true;
                                    break;
                                }
                            }

                            if (correctNumberIsFound)
                            {
                                break;
                            }
                        }

                        int swappedNumber = matrix[i][j];
                        matrix[i][j] = matrix[correctNumberRowIndex][correctNumberColumnIndex];
                        matrix[correctNumberRowIndex][correctNumberColumnIndex] = swappedNumber;

                        Console.WriteLine($"Swap ({i}, {j}) with ({correctNumberRowIndex}, {correctNumberColumnIndex})");
                    }
                }
            }
        }

        private static void ShuffleMatrix(int[][] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');

                int columOrRowIndex = int.Parse(command[0]);
                string direction = command[1];
                int moveCount = int.Parse(command[2]);

                if (direction == "up")
                {
                    for (int j = 0; j < moveCount % matrix.Length; j++)
                    {
                        int firstShuffedNumber = matrix[0][columOrRowIndex];

                        for (int k = 0; k < matrix.Length - 1; k++)
                        {
                            matrix[k][columOrRowIndex] = matrix[k + 1][columOrRowIndex];
                        }

                        matrix[matrix.Length - 1][columOrRowIndex] = firstShuffedNumber;
                    }
                }
                else if (direction == "down")
                {
                    for (int j = 0; j < moveCount % matrix.Length; j++)
                    {
                        int firstShuffedNumber = matrix[matrix.Length - 1][columOrRowIndex];

                        for (int k = matrix.Length - 1; k > 0; k--)
                        {
                            matrix[k][columOrRowIndex] = matrix[k - 1][columOrRowIndex];
                        }

                        matrix[0][columOrRowIndex] = firstShuffedNumber;
                    }
                }
                else if (direction == "left")
                {
                    for (int j = 0; j < moveCount % matrix[0].Length; j++)
                    {
                        int firstShuffedNumber = matrix[columOrRowIndex][0];

                        for (int k = 0; k < matrix.Length - 1; k++)
                        {
                            matrix[columOrRowIndex][k] = matrix[columOrRowIndex][k + 1];
                        }

                        matrix[columOrRowIndex][matrix.Length - 1] = firstShuffedNumber;
                    }
                }
                else if (direction == "right")
                {
                    for (int j = 0; j < moveCount % matrix[0].Length; j++)
                    {
                        int firstShuffedNumber = matrix[columOrRowIndex][matrix.Length - 1];

                        for (int k = matrix.Length - 1; k > 0; k--)
                        {
                            matrix[columOrRowIndex][k] = matrix[columOrRowIndex][k - 1];
                        }

                        matrix[columOrRowIndex][0] = firstShuffedNumber;
                    }
                }
            }
        }

        private static void FillInMatrix(int[][] matrix, int rows, int colums, int[][] fixedMatrix)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[colums];
                fixedMatrix[i] = new int[colums];
            }

            int counter = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    counter++;
                    matrix[i][j] = counter;
                    fixedMatrix[i][j] = counter;
                }
            }
        }
    }
}
