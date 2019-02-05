using System;

public delegate void AttackedEventHandler(object sender, EventArgs eventArgs);

public class King : IKing
{
    public event AttackedEventHandler Attacked;
    public string Name { get; private set; }

    public King(string name)
    {
        this.Name = name;
    }

    public void BeAttacked()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        this.OnAttacked();
    }

    protected void OnAttacked()
    {
        if (this.Attacked != null)
        {
            this.Attacked(this, new EventArgs());
        }
    }
}

