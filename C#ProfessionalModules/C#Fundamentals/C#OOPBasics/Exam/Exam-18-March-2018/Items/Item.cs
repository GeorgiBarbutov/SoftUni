using System;

public abstract class Item
{
    public int Weight { get; private set; }

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public abstract void AffectCharacter(Character character);

}

