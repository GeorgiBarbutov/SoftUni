using System;

public abstract class Provider : Unit
{
    private const int MAX_ENERGY_OUTPUT = 10000;

    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        string name = null;

        if (this.GetType().Name.Length == 13)
            name = "Solar";
        else
            name = "Pressure";

        return $"{name} Provider - {this.Id}" + Environment.NewLine +
        $"Energy Output: {this.EnergyOutput}";
    }

    public double EnergyOutput
    {
        get { return energyOutput; }

        protected set
        {
            if (value > MAX_ENERGY_OUTPUT)
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");

            energyOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}

