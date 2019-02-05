using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<ISoldier> soldiers = new List<ISoldier>();
        AddSoldiers(soldiers);

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void AddSoldiers(List<ISoldier> soldiers)
    {
        string[] inputParams;

        while ((inputParams = Console.ReadLine().Split(' '))[0] != "End")
        {
            if (inputParams[0] == "Private")
            {
                AddPrivate(soldiers, inputParams);
            }
            else if (inputParams[0] == "LeutenantGeneral")
            {
                AddLeutenantGeneral(soldiers, inputParams);
            }
            else if (inputParams[0] == "Engineer")
            {
                AddEnginner(soldiers, inputParams);
            }
            else if (inputParams[0] == "Commando")
            {
                AddCommando(soldiers, inputParams);
            }
            else if (inputParams[0] == "Spy")
            {
                AddSpy(soldiers, inputParams);
            }
        }
    }

    private static void AddCommando(List<ISoldier> soldiers, string[] inputParams)
    {
        try
        {
            Commando commando = new Commando(inputParams[1], inputParams[2], inputParams[3],
                            double.Parse(inputParams[4]), inputParams[5]);

            int numberOfMissions = (inputParams.Length - 5) / 2;

            for (int i = 0; i < numberOfMissions; i++)
            {
                AddMissions(inputParams, commando, i);
            }

            soldiers.Add(commando);
        }
        catch (ArgumentException e)
        {

        }
    }

    private static void AddMissions(string[] inputParams, Commando commando, int i)
    {
        try
        {
            Mission mission = new Mission(inputParams[6 + (i * 2)], inputParams[7 + (i * 2)]);

            commando.AddMission(mission);
        }
        catch (ArgumentException e)
        {

        }
    }

    private static void AddSpy(List<ISoldier> soldiers, string[] inputParams)
    {
        Spy spy = new Spy(inputParams[1], inputParams[2], inputParams[3],
                                    int.Parse(inputParams[4]));

        soldiers.Add(spy);
    }

    private static void AddEnginner(List<ISoldier> soldiers, string[] inputParams)
    {
        try
        {
            TryCreateEnginner(soldiers, inputParams);
        }
        catch (ArgumentException e)
        {

        }
    }

    private static void TryCreateEnginner(List<ISoldier> soldiers, string[] inputParams)
    {
        Engineer engineer = new Engineer(inputParams[1], inputParams[2], inputParams[3],
                                    double.Parse(inputParams[4]), inputParams[5]);

        int numberOfRepairs = (inputParams.Length - 5) / 2;

        for (int i = 0; i < numberOfRepairs; i++)
        {
            Repair repair = new Repair(inputParams[6 + (i * 2)], int.Parse(inputParams[7 + (i * 2)]));

            engineer.AddRepair(repair);
        }

        soldiers.Add(engineer);
    }

    private static void AddLeutenantGeneral(List<ISoldier> soldiers, string[] inputParams)
    {
        LeutenantGeneral leutenantGeneral = new LeutenantGeneral(inputParams[1], inputParams[2], inputParams[3],
                                    double.Parse(inputParams[4]));

        int numberOfPrivates = inputParams.Length - 5;

        for (int i = 0; i < numberOfPrivates; i++)
        {
            Private _private = (Private)soldiers.FirstOrDefault(x => x.Id == inputParams[5 + i]);

            leutenantGeneral.AddPrivate(_private);
        }

        soldiers.Add(leutenantGeneral);
    }

    private static void AddPrivate(List<ISoldier> soldiers, string[] inputParams)
    {
        Private _private = new Private(inputParams[1], inputParams[2], inputParams[3],
                            double.Parse(inputParams[4]));

        soldiers.Add(_private);
    }
}

