using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IAlive> livingThings = new List<IAlive>();

        AddLivingThings(livingThings);
        Print(livingThings);
    }

    private static void Print(List<IAlive> livingThings)
    {
        string year = Console.ReadLine();

        foreach (var animal in livingThings)
        {
            if (animal.Birthdate.Split('/')[2] == year)
            {
                Console.WriteLine(animal.Birthdate);
            }
        }
    }

    private static void AddLivingThings(List<IAlive> livingThings)
    {
        string[] inputParams;

        while ((inputParams = Console.ReadLine().Split(' '))[0] != "End")
        {
            if (inputParams.Length == 5)
            {
                AddHuman(livingThings, inputParams);
            }
            else if (inputParams[0] == "Pet")
            {
                AddPet(livingThings, inputParams);
            }
        }
    }

    private static void AddPet(List<IAlive> livingThings, string[] inputParams)
    {
        string name = inputParams[1];
        string birthdate = inputParams[2];

        livingThings.Add(new Pet(name, birthdate));
    }

    private static void AddHuman(List<IAlive> livingThings, string[] inputParams)
    {
        string name = inputParams[1];
        int age = int.Parse(inputParams[2]);
        string id = inputParams[3];
        string birthdate = inputParams[4];

        livingThings.Add(new Human(name, age, id, birthdate));
    }
}

