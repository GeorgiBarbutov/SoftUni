using System;
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public Team(string name)
    {
        Name = name;
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
            firstTeam.Add(person);
        else
            reserveTeam.Add(person);
    }

    public void Print()
    {
        Console.WriteLine($"First team has {FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {ReserveTeam.Count} players.");
    }
}

