using System;
using System.Collections.Generic;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = Console.ReadLine()
                    .ToCharArray();
            }

            char[] directions = Console.ReadLine().ToCharArray();

            List<long[]> bEnemyPositions = new List<long[]>();
            List<long[]> dEnemyPositions = new List<long[]>();
            long[] NikoladzePosition = new long[2];
            long[] samPosition = new long[2];

            FillStartingPositions(bEnemyPositions, dEnemyPositions, NikoladzePosition, samPosition, n, board);

            PlayGame(bEnemyPositions, dEnemyPositions, board, NikoladzePosition, samPosition, directions);
            

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void PlayGame(List<long[]> bEnemyPositions, List<long[]> dEnemyPositions, char[][] board, long[] NikoladzePosition, long[] samPosition, char[] directions)
        {
            bool samIsAlive = true;
            bool nikoladzeIsAlive = true;

            long currentDirectionIndex = 0;

            while (samIsAlive && nikoladzeIsAlive)
            {
                long samiPosition = samPosition[0];
                long samjPosition = samPosition[1];
                long bEnemyToWaitI = -1;
                long bEnemyToWaitJ = -1;

                    for (int i = 0; i < bEnemyPositions.Count; i++)
                    {
                        long[] bEnemy = bEnemyPositions[i];

                        long bEnemyiPosition = bEnemy[0];
                        long bEnemyjPosition = bEnemy[1];

                        if (bEnemyjPosition == board[bEnemyiPosition].Length - 1)
                        {
                            board[bEnemyiPosition][bEnemyjPosition] = 'd';

                            bEnemyPositions.Remove(bEnemy);

                        bEnemyToWaitI = bEnemyiPosition;
                        bEnemyToWaitJ = bEnemyjPosition;

                            i--;
                        }
                        else
                        {
                            board[bEnemyiPosition][bEnemyjPosition] = '.';
                            board[bEnemyiPosition][bEnemyjPosition + 1] = 'b';

                            long[] newbEnemy = new long[] { bEnemyiPosition, bEnemyjPosition + 1 };

                            bEnemyPositions[i] = newbEnemy;
                        }
                    }

                    for (int i = 0; i < dEnemyPositions.Count; i++)
                    {
                        long[] dEnemy = dEnemyPositions[i];

                        long dEnemyiPosition = dEnemy[0];
                        long dEnemyjPosition = dEnemy[1];

                        if (dEnemyjPosition == 0)
                        {
                            board[dEnemyiPosition][dEnemyjPosition] = 'b';

                            dEnemyPositions.Remove(dEnemy);
                            i--;
                            bEnemyPositions.Add(dEnemy);
                        }
                        else
                        {
                            board[dEnemyiPosition][dEnemyjPosition] = '.';
                            board[dEnemyiPosition][dEnemyjPosition - 1] = 'd';

                            long[] newdEnemy = new long[] { dEnemyiPosition, dEnemyjPosition - 1 };

                            dEnemyPositions[i] = newdEnemy;
                        }
                    }


                if (bEnemyToWaitI != -1)
                {
                    dEnemyPositions.Add(new long[] { bEnemyToWaitI, bEnemyToWaitJ });
                }
                for (int i = 0; i < bEnemyPositions.Count; i++)
                {
                    if (samiPosition == bEnemyPositions[i][0] && samjPosition > bEnemyPositions[i][1])
                    {
                        board[samiPosition][samjPosition] = 'X';
                        samIsAlive = false;
                    }
                }

                for (int i = 0; i < dEnemyPositions.Count; i++)
                {
                    if (samiPosition == dEnemyPositions[i][0] && samjPosition < dEnemyPositions[i][1])
                    {
                        board[samiPosition][samjPosition] = 'X';
                        samIsAlive = false;
                    }
                }

                if (!samIsAlive)
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    break;
                }
                else
                {
                    char currentDirection = directions[currentDirectionIndex];

                    if (currentDirection == 'U')
                    {
                        long newSamiPosition = samiPosition - 1;
                        long newSamjPosition = samjPosition;

                        board[samiPosition][samjPosition] = '.';
                        board[newSamiPosition][newSamjPosition] = 'S';

                        samiPosition = newSamiPosition;
                        samjPosition = newSamjPosition;

                        samPosition[0] = samiPosition;
                        samPosition[1] = samjPosition;

                        for (int i = 0; i < bEnemyPositions.Count; i++)
                        {
                            if (samiPosition == bEnemyPositions[i][0] && samjPosition == bEnemyPositions[i][1])
                            {
                                bEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        for (int i = 0; i < dEnemyPositions.Count; i++)
                        {
                            if (samiPosition == dEnemyPositions[i][0] && samjPosition == dEnemyPositions[i][1])
                            {
                                dEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        currentDirectionIndex++;
                    }

                    if (currentDirection == 'L')
                    {
                        long newSamiPosition = samiPosition;
                        long newSamjPosition = samjPosition - 1;

                        board[samiPosition][samjPosition] = '.';
                        board[newSamiPosition][newSamjPosition] = 'S';

                        samiPosition = newSamiPosition;
                        samjPosition = newSamjPosition;

                        samPosition[0] = samiPosition;
                        samPosition[1] = samjPosition;

                        for (int i = 0; i < bEnemyPositions.Count; i++)
                        {
                            if (samiPosition == bEnemyPositions[i][0] && samjPosition == bEnemyPositions[i][1])
                            {
                                bEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        for (int i = 0; i < dEnemyPositions.Count; i++)
                        {
                            if (samiPosition == dEnemyPositions[i][0] && samjPosition == dEnemyPositions[i][1])
                            {
                                dEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        currentDirectionIndex++;
                    }

                    if (currentDirection == 'R')
                    {
                        long newSamiPosition = samiPosition;
                        long newSamjPosition = samjPosition + 1;

                        board[samiPosition][samjPosition] = '.';
                        board[newSamiPosition][newSamjPosition] = 'S';

                        samiPosition = newSamiPosition;
                        samjPosition = newSamjPosition;

                        samPosition[0] = samiPosition;
                        samPosition[1] = samjPosition;

                        for (int i = 0; i < bEnemyPositions.Count; i++)
                        {
                            if (samiPosition == bEnemyPositions[i][0] && samjPosition == bEnemyPositions[i][1])
                            {
                                bEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        for (int i = 0; i < dEnemyPositions.Count; i++)
                        {
                            if (samiPosition == dEnemyPositions[i][0] && samjPosition == dEnemyPositions[i][1])
                            {
                                dEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        currentDirectionIndex++;
                    }

                    if (currentDirection == 'D')
                    {
                        long newSamiPosition = samiPosition + 1;
                        long newSamjPosition = samjPosition;

                        board[samiPosition][samjPosition] = '.';
                        board[newSamiPosition][newSamjPosition] = 'S';

                        samiPosition = newSamiPosition;
                        samjPosition = newSamjPosition;

                        samPosition[0] = samiPosition;
                        samPosition[1] = samjPosition;

                        for (int i = 0; i < bEnemyPositions.Count; i++)
                        {
                            if (samiPosition == bEnemyPositions[i][0] && samjPosition == bEnemyPositions[i][1])
                            {
                                bEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        for (int i = 0; i < dEnemyPositions.Count; i++)
                        {
                            if (samiPosition == dEnemyPositions[i][0] && samjPosition == dEnemyPositions[i][1])
                            {
                                dEnemyPositions.RemoveAt(i);
                                break;
                            }
                        }

                        currentDirectionIndex++;
                    }

                    if (currentDirection == 'W')
                    {
                        currentDirectionIndex++;
                    }

                    if (samiPosition == NikoladzePosition[0])
                    {
                        board[NikoladzePosition[0]][NikoladzePosition[1]] = 'X';
                        nikoladzeIsAlive = false;
                    }
                }

                if (!samIsAlive)
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                }

                if (!nikoladzeIsAlive)
                {
                    Console.WriteLine($"Nikoladze killed!");
                }
            }
        }

        private static void FillStartingPositions(List<long[]> bEnemyPositions, List<long[]> dEnemyPositions, long[] NikoladzePosition, long[] samPosition, long n, char[][] board)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'N')
                    {
                        NikoladzePosition[0] = i;
                        NikoladzePosition[1] = j;
                    }
                    else if (board[i][j] == 'b')
                    {
                        bEnemyPositions.Add(new long[] { i, j });
                    }
                    else if (board[i][j] == 'd')
                    {
                        dEnemyPositions.Add(new long[] { i, j });
                    }
                    else if (board[i][j] == 'S')
                    {
                        samPosition[0] = i;
                        samPosition[1] = j;
                    }
                }
            }

        }
    }
}
