using System;

public class Warrior : Character, IAttackable
{
    public Warrior(string name, Faction faction) 
        : base(name, 100, 50, 40, new Satchel(), faction)
    {
    }

    public void Attack(Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if(this.Equals(character))
        {
            throw new InvalidOperationException("Cannot attack self!");
        }

        if(this.Faction == character.Faction)
        {
            throw new ArgumentException("Friendly fire! Both characters are from {faction} faction!");
        }

        character.TakeDamage(this.AbilityPoints);
    }
}

