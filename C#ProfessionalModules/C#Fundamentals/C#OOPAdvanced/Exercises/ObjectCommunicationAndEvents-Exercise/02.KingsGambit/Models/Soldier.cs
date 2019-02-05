using System;

public abstract class Soldier : ISoldier
{
    protected string displayMassege;

    public string Name { get; private set; }

    protected Soldier(string name)
    {
        this.Name = name;
    }

    public void Die(IKing king)
    {
        king.Attacked -= this.OnKingAttacked;
    }

    public void OnKingAttacked(object sender, EventArgs eventArgs)
    {
        Console.WriteLine(this.displayMassege);
    }
}

