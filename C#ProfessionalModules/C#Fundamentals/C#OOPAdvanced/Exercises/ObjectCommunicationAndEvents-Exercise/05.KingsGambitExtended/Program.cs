using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string kingName = Console.ReadLine();

        IKing king = new King(kingName);
        IList<ISoldier> soldiers = GetSoldiers(king);

        Run(king, soldiers);
    }

    private static void Run(IKing king, IList<ISoldier> soldiers)
    {
        string[] commandArgs;

        while ((commandArgs = Console.ReadLine().Split(' '))[0] != "End")
        {
            if (commandArgs[0] == "Attack")
            {
                king.BeAttacked();
            }
            else if (commandArgs[0] == "Kill")
            {
                soldiers.First(x => x.Name == commandArgs[1]).DecreaseHealth(king);
            }
        }
    }

    private static IList<ISoldier> GetSoldiers(IKing king)
    {
        string[] royalGuardsNames = Console.ReadLine().Split(' ');
        string[] footmanNames = Console.ReadLine().Split(' ');

        IList<ISoldier> soldiers = new List<ISoldier>();

        foreach (var name in royalGuardsNames)
        {
            ISoldier soldier = new RoyalGuard(name);
            king.Attacked += soldier.OnKingAttacked;
            soldiers.Add(soldier);
        }
        foreach (var name in footmanNames)
        {
            ISoldier soldier = new Footman(name);
            king.Attacked += soldier.OnKingAttacked;
            soldiers.Add(soldier);
        }

        return soldiers;
    }
}

