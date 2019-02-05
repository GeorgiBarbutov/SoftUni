using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0 && n == 1 && n == 2)
            {
                Console.WriteLine(0);
            }
            else
            {
                char[][] board = new char[n][];

                for (int i = 0; i < n; i++)
                {
                    string lineInput = Console.ReadLine();

                    board[i] = new char[n];

                    for (int j = 0; j < n; j++)
                    {
                        board[i][j] = lineInput[j];
                    }
                }

                List<int[]> listOfKnights = new List<int[]>();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (board[i][j] == 'K')
                        {
                            listOfKnights.Add(new int[3]);
                            listOfKnights[listOfKnights.Count - 1][0] = i;
                            listOfKnights[listOfKnights.Count - 1][1] = j;
                        }
                    }
                }

                int currentKnightIndex = 0;

                foreach (var knight in listOfKnights)
                {
                    int numberOfOtherKnightsAttacked = 0;

                    int currentKnightRow = knight[0];
                    int currentKnightColumn = knight[1];

                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -2, -1, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -2, 1, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -1, -2, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 1, -2, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -1, 2, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 1, 2, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 2, -1, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }
                    if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 2, 1, n, board))
                    {
                        numberOfOtherKnightsAttacked++;
                    }

                    listOfKnights[currentKnightIndex][2] = numberOfOtherKnightsAttacked;

                    currentKnightIndex++;
                }

                List<int[]> orderedListOfKnights = listOfKnights.OrderBy(x => x[2]).ToList();

                int minimumAmountNeeded = 0;

                if (orderedListOfKnights[orderedListOfKnights.Count - 1][2] == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    for (int i = orderedListOfKnights.Count - 1; i >= 0; i--)
                    {
                        int removedKnightRowIndex = orderedListOfKnights[i][0];
                        int removedKnightColumnIndex = orderedListOfKnights[i][1];

                        board[removedKnightRowIndex][removedKnightColumnIndex] = '0';
                        minimumAmountNeeded++;
                        orderedListOfKnights.RemoveAt(orderedListOfKnights.Count - 1);

                        bool needsToBeRemoved = false;

                        int knightCount = orderedListOfKnights.Count - 1;

                        for (int j = knightCount; j >= 0; j--)
                        {
                            int newCurrentKnightIndex = 0;

                            foreach (var knight in orderedListOfKnights)
                            {
                                int numberOfOtherKnightsAttacked = 0;

                                int newCurrentKnightRow = knight[0];
                                int newCurrentKnightColumn = knight[1];

                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, -2, -1, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, -2, 1, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, -1, -2, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, 1, -2, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, -1, 2, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, 1, 2, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, 2, -1, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }
                                if (isAttackingOtherKnights(newCurrentKnightRow, newCurrentKnightColumn, 2, 1, n, board))
                                {
                                    numberOfOtherKnightsAttacked++;
                                }

                                orderedListOfKnights[newCurrentKnightIndex][2] = numberOfOtherKnightsAttacked;

                                newCurrentKnightIndex++;
                            }

                            orderedListOfKnights = orderedListOfKnights.OrderBy(x => x[2]).ToList();
                            int currentKnightRow = orderedListOfKnights[j][0];
                            int currentKnightColumn = orderedListOfKnights[j][1];

                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -2, -1, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -2, 1, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -1, -2, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 1, -2, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, -1, 2, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 1, 2, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 2, -1, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }
                            if (isAttackingOtherKnights(currentKnightRow, currentKnightColumn, 2, 1, n, board))
                            {
                                needsToBeRemoved = true;
                                break;
                            }


                        }
                        if (!needsToBeRemoved)
                        {
                            Console.WriteLine(minimumAmountNeeded);
                            break;
                        }
                    }
                }
            }
        }

        private static bool isAttackingOtherKnights(int currentKnightRow, int currentKnightColumn, int rowDifference, int columnDifference, int n, char[][] board)
        {
            int newKnightRowIndex = currentKnightRow + rowDifference;
            int newKnightColumnIndex = currentKnightColumn + columnDifference;

            if (newKnightRowIndex >= 0 && newKnightRowIndex < n)
            {
                if (newKnightColumnIndex >= 0 && newKnightColumnIndex < n)
                {
                    if(board[newKnightRowIndex][newKnightColumnIndex] == 'K')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
