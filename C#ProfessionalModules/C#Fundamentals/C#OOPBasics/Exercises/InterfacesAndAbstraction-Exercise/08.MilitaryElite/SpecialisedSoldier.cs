using System;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
    }

    public string Corps
    {
        get
        {
            return this.corps;
        }

        private set
        {
            if (value != "Airforces" && value != "Marines")
                throw new ArgumentException();

            this.corps = value;
        }
    }
}
