using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Citizen> citizens = new List<Citizen>();

        AddCitizens(citizens);
        PrintCitizens(citizens);
    }

    private static void PrintCitizens(List<Citizen> citizens)
    {
        foreach (var citizen in citizens)
        {
            IPerson person = citizen;
            Console.WriteLine(person.GetName());

            IResident resident = citizen;
            Console.WriteLine(resident.GetName());           
        }
    }

    private static void AddCitizens(List<Citizen> citizens)
    {
        string[] citizenParams;

        while ((citizenParams = Console.ReadLine().Split(' '))[0] != "End")
        {
            string name = citizenParams[0];
            string country = citizenParams[1];
            int age = int.Parse(citizenParams[2]);

            citizens.Add(new Citizen(name, country, age));
        }
    }
}

