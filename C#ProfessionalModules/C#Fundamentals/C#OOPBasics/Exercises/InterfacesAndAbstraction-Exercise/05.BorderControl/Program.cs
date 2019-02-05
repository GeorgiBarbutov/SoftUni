using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IMigrant> migrants = new List<IMigrant>();

        AddMigrants(migrants);
        PrintFakeIDs(migrants);
    }

    private static void PrintFakeIDs(List<IMigrant> migrants)
    {
        string fakeId = Console.ReadLine();

        foreach (var migrant in migrants)
        {
            if (migrant.Id.Substring(migrant.Id.Length - fakeId.Length) == fakeId)
            {
                Console.WriteLine(migrant.Id);
            }
        }
    }

    private static void AddMigrants(List<IMigrant> migrants)
    {
        string[] migrantParams;

        while ((migrantParams = Console.ReadLine().Split(' '))[0] != "End")
        {
            if (migrantParams.Length == 3)
            {
                AddHuman(migrants, migrantParams);
            }
            else
            {
                AddRobot(migrants, migrantParams);
            }
        }
    }

    private static void AddRobot(List<IMigrant> migrants, string[] migrantParams)
    {
        string model = migrantParams[0];
        string id = migrantParams[1];

        migrants.Add(new Robot(model, id));
    }

    private static void AddHuman(List<IMigrant> migrants, string[] migrantParams)
    {
        string name = migrantParams[0];
        int age = int.Parse(migrantParams[1]);
        string id = migrantParams[2];

        migrants.Add(new Human(name, age, id));
    }
}

