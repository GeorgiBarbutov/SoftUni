using System;
using System.Collections.Generic;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private List<Repair> repairs;

    public Engineer(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<Repair>();
    }

    public void AddRepair(Repair repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        string result = base.ToString() + Environment.NewLine + "Repairs:";

        foreach (var repair in repairs)
        {
            result += Environment.NewLine + "  " + repair.ToString();
        }

        return result;
    }
}
