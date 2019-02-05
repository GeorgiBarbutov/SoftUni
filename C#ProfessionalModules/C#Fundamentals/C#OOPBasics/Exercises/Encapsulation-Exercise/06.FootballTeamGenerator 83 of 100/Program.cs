using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        ExecuteCommands(teams);
    }

    private static void ExecuteCommands(List<Team> teams)
    {
        string[] commandInput;
        while ((commandInput = Console.ReadLine().Split(';'))[0] != "END")
        {
            try
            {
                if (commandInput[0] == "Team")
                {
                    AddTeams(teams, commandInput);
                }
                else if (commandInput[0] == "Add")
                {
                    AddPlayer(teams, commandInput);
                }
                else if (commandInput[0] == "Remove")
                {
                    RemovePlayer(teams, commandInput);
                }
                else if (commandInput[0] == "Rating")
                {
                    PrintRating(teams, commandInput);
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }

    private static void PrintRating(List<Team> teams, string[] commandInput)
    {
        string teamName = commandInput[1];

        Team team = teams.FirstOrDefault(x => x.Name == teamName);

        if (team == null)
            throw new ArgumentException($"Team {teamName} does not exist.");
        else
            teams[teams.IndexOf(team)].PrintRating();
    }

    private static void RemovePlayer(List<Team> teams, string[] commandInput)
    {
        string teamName = commandInput[1];
        string playerName = commandInput[2];

        Team team = teams.FirstOrDefault(x => x.Name == teamName);

        if (team == null)
            throw new ArgumentException($"Team {teamName} does not exist.");
        else
            teams[teams.IndexOf(team)].RemovePlayer(playerName);
    }

    private static void AddPlayer(List<Team> teams, string[] commandInput)
    {
        string teamName = commandInput[1];
        string playerName = commandInput[2];
        int endurance = int.Parse(commandInput[3]);
        int sprint = int.Parse(commandInput[4]);
        int dribble = int.Parse(commandInput[5]);
        int passing = int.Parse(commandInput[6]);
        int shooting = int.Parse(commandInput[7]);

        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

        Team team = teams.FirstOrDefault(x => x.Name == teamName);

        if (team == null)
            throw new ArgumentException($"Team {teamName} does not exist.");
        else
            teams[teams.IndexOf(team)].AddPlayer(player);
    }

    private static void AddTeams(List<Team> teams, string[] commandInput)
    {
        Team team = new Team(commandInput[1]);

        teams.Add(team);
    }
}

