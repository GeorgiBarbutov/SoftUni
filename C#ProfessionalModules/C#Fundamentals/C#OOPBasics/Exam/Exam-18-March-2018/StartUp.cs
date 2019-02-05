using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            string input;
            DungeonMaster dungeonMaster = new DungeonMaster();

            do
            {
                input = Console.ReadLine();
                string[] arguments = input.Split(' ');

                try
                {
                    try
                    {
                        if (arguments[0] == "JoinParty")
                        {
                            Console.WriteLine(dungeonMaster.JoinParty(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "AddItemToPool")
                        {
                            Console.WriteLine(dungeonMaster.AddItemToPool(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "PickUpItem")
                        {
                            Console.WriteLine(dungeonMaster.PickUpItem(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "UseItem")
                        {
                            Console.WriteLine(dungeonMaster.UseItem(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "UseItemOn")
                        {
                            Console.WriteLine(dungeonMaster.UseItemOn(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "GiveCharacterItem")
                        {
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "GetStats")
                        {
                            Console.WriteLine(dungeonMaster.GetStats());
                        }
                        else if (arguments[0] == "Attack")
                        {
                            Console.WriteLine(dungeonMaster.Attack(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "Heal")
                        {
                            Console.WriteLine(dungeonMaster.Heal(arguments.Skip(1).ToArray()));
                        }
                        else if (arguments[0] == "EndTurn")
                        {
                            Console.WriteLine(dungeonMaster.EndTurn());

                            if (dungeonMaster.LastSurvivorRounds > 1)
                            {
                                Console.WriteLine("Final stats:");
                                Console.WriteLine(dungeonMaster.GetStats());

                                break;
                            }
                        }
                        else if (arguments[0] == "IsGameOver")
                        {
                            if (dungeonMaster.IsGameOver())
                            {
                                break;
                            }
                        }                       
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Parameter Error: " + e.Message);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
                
            } while (!String.IsNullOrEmpty(input));
		}
	}
}