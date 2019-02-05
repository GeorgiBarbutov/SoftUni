using System;

public abstract class Soldier : ISoldier
{
    private const int MIN_HEALTH = 0;

    protected string displayMessage;

    public string Name { get; private set; }
    public int Health { get; private set; }

    protected Soldier(string name, int health, string displayMessage)
    {
        this.Name = name;
        this.Health = health;
        this.displayMessage = displayMessage;
    }

    public void DecreaseHealth(IKing king)
    {
        this.Health -= 1;

        if(this.Health <= MIN_HEALTH)
        {
            this.Die(king);
        }
    }

    private void Die(IKing king)
    {
        king.Attacked -= this.OnKingAttacked;
    }

    public void OnKingAttacked(object sender, EventArgs eventArgs)
    {
        Console.WriteLine(this.displayMessage);
    }
}

