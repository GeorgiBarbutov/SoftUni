using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private int rating;
    private List<Player> players;

    private Team()
    {
        Players = new List<Player>();
    }

    public Team(string name):this()
    {
        Name = name;
        Rating = 0;
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player player = Players.FirstOrDefault(x => x.Name == playerName);

        if(player == null)
            throw new ArgumentException($"Player {playerName} is not in {Name} team.");
        else
            Players.Remove(player);
    }

    public void PrintRating()
    {
        int rating = Rating;

        if (players.Count > 0)
            rating = CalculateRating();

        Console.WriteLine($"{Name} - {rating}");
    }

    private int CalculateRating()
    {
        double sumOfSkills = GetSkillSum();

        return (int)Math.Round((sumOfSkills / 5.0) / Players.Count);
    }

    private double GetSkillSum()
    {
        double sumOfSkills = 0;
        foreach (var player in Players)
        {
            sumOfSkills += player.OverallSkill;
        }

        return sumOfSkills;
    }

    private List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    private int Rating
    {
        get { return rating; }
        set { rating = value; }
    }

    public string Name
    {
        get { return name; }

        private set
        {
            if (String.IsNullOrEmpty(value.Trim()))
                throw new ArgumentException("A name should not be empty.");

            name = value;
        }
    }
}

