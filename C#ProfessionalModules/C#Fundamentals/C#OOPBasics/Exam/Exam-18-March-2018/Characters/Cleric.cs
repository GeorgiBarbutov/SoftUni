using System;

public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction) 
        : base(name, 50, 25, 40, new Backpack(), faction)
    {
        this.RestHealMultiplier = 0.5;
    }

    public void Heal(Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if(this.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }

        character.Health += this.AbilityPoints;

        if(character.Health > character.BaseHealth)
        {
            character.Health = character.BaseHealth;
        }
    }

    public override double RestHealMultiplier { get; protected set; } ////?
}

