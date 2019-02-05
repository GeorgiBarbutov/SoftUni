using System;
using System.Collections.Generic;

public class Commando : SpecialisedSoldier, ICommando
{
    private List<Mission> missions;

    public Commando(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<Mission>();
    }

    public void AddMission(Mission mission)
    {
        this.missions.Add(mission);
    }

    public override string ToString()
    {
        string result = base.ToString() + Environment.NewLine + "Missions:";

        foreach (var mission in missions)
        {
            result += Environment.NewLine + "  " + mission.ToString();
        }

        return result;
    }
}

