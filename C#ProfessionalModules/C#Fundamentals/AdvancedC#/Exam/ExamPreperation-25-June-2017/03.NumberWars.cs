using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> player1Cards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Queue<string> player2Cards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            PlayTheGame(player1Cards, player2Cards);
        }

        private static void PlayTheGame(Queue<string> player1Cards, Queue<string> player2Cards)
        {
            int turnCounter = 0;

            int winnerNumber = 0;

            bool hasToBreak = false;

            while (turnCounter != 1000000 && !hasToBreak)
            {  
                turnCounter++;

                string player1Card = player1Cards.Dequeue();
                string player2Card = player2Cards.Dequeue();

                List<string> allPlayedCards = new List<string>();

                int player1Sum = 0;
                int player2Sum = 0;

                int player1CardValue = int.Parse(player1Card.Substring(0, player1Card.Length - 1));
                int player2CardValue = int.Parse(player2Card.Substring(0, player2Card.Length - 1));

                if (player1CardValue > player2CardValue)
                {
                    player1Cards.Enqueue(player1Card);
                    player1Cards.Enqueue(player2Card);

                    if (player2Cards.Count == 0)
                    {
                        winnerNumber = 1;
                        break;
                    }
                }
                else if (player1CardValue < player2CardValue)
                {
                    player2Cards.Enqueue(player2Card);
                    player2Cards.Enqueue(player1Card);

                    if (player1Cards.Count == 0)
                    {
                        winnerNumber = 2;
                        break;
                    }
                }
                else
                {
                    do
                    {
                        if (player1Cards.Count < 3 && player2Cards.Count < 3)
                        {
                            hasToBreak = true;
                            break;
                        }
                        else if (player1Cards.Count < 3)
                        {
                            winnerNumber = 2;
                            hasToBreak = true;
                            break;
                        }
                        else if (player2Cards.Count < 3)
                        {
                            winnerNumber = 1;
                            hasToBreak = true;
                            break;
                        }
                        else
                        {
                            allPlayedCards.Add(player1Card);
                            allPlayedCards.Add(player2Card);

                            for (int i = 0; i < 3; i++)
                            {
                                string player1ExtraCard = player1Cards.Dequeue();
                                player1Sum += (int)(player1ExtraCard.ToLower().Last());

                                string player2ExtraCard = player2Cards.Dequeue();
                                player2Sum += (int)(player2ExtraCard.ToLower().Last());

                                allPlayedCards.Add(player1ExtraCard);
                                allPlayedCards.Add(player2ExtraCard);
                            }
                        }
                    } while (player1Sum == player2Sum);

                    if(hasToBreak == true)
                    {
                        break;
                    }
                    else
                    {
                        allPlayedCards = allPlayedCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ThenByDescending(x => x.Last()).ToList();

                        if(player1Sum > player2Sum)
                        {
                            for (int i = 0; i < allPlayedCards.Count; i++)
                            {
                                player1Cards.Enqueue(allPlayedCards[i]);
                            }
                            
                            if(player2Cards.Count == 0)
                            {
                                winnerNumber = 1;
                                break;
                            }    
                        }
                        else
                        {
                            for (int i = 0; i < allPlayedCards.Count; i++)
                            {
                                player2Cards.Enqueue(allPlayedCards[i]);
                            }

                            if (player1Cards.Count == 0)
                            {
                                winnerNumber = 2;
                                break;
                            }
                        }
                    }
                } 
            }

            if(turnCounter == 1000000)
            {
                if(player1Cards.Count > player2Cards.Count)
                {
                    winnerNumber = 1;
                }
                else if (player2Cards.Count > player1Cards.Count)
                {
                    winnerNumber = 2;
                }
                else
                {
                    winnerNumber = 0;
                }
            }

            if(winnerNumber == 1)
            {
                Console.WriteLine($"First player wins after {turnCounter} turns");
            }
            else if(winnerNumber == 2)
            {
                Console.WriteLine($"Second player wins after {turnCounter} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turnCounter} turns");
            }
        }
    }
}
