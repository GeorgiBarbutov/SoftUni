﻿public class Repair : IRepair
{
    public Repair(string partName, int workHours)
    {
        this.PartName = partName;
        this.WorkHours = workHours;
    }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.WorkHours}";
    }

    public string PartName { get; private set; }
    public int WorkHours { get; private set; }
}