using System;

public abstract class Harvester : Unit
{
    private const int MIN_ENERGY_REQUIREMENT = 0;
    private const int MAX_ENERGY_REQUIREMENT = 20000;
    private const int MIN_ORE_OUTPUT = 0;

    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        string name = null;

        if (this.GetType().Name.Length == 14)
            name = "Sonic";
        else
            name = "Hammer";

        return $"{name} Harvester - {this.Id}" + Environment.NewLine +
        $"Ore Output: {this.OreOutput}" + Environment.NewLine +
        $"Energy Requirement: {this.EnergyRequirement}";
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }

        protected set
        {
            if (value < MIN_ENERGY_REQUIREMENT || value > MAX_ENERGY_REQUIREMENT)
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");

            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }

        protected set
        {
            if (value < MIN_ORE_OUTPUT)
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");

            oreOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}

