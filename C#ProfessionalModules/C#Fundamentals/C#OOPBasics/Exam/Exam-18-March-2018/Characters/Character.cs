using System;

public abstract class Character
{
    string name;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
        this.RestHealMultiplier = 0.2;
    }

    public void TakeDamage(double hitPoints)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if(this.Armor > hitPoints)
        {
            this.Armor -= hitPoints;
        }
        else
        {
            hitPoints -= this.Armor;
            this.Armor = 0;
            this.Health -= hitPoints;

            if(this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }
    }
    public void Rest()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        this.Health += (this.BaseHealth * this.RestHealMultiplier);

        if(this.Health > this.BaseHealth)
        {
            this.Health = this.BaseHealth;
        }
    }
    public void UseItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        item.AffectCharacter(this);
    }
    public void UseItemOn(Item item, Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        item.AffectCharacter(character);
    }
    public void GiveCharacterItem(Item item, Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        character.ReceiveItem(item);
    }
    public void ReceiveItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        this.Bag.AddItem(item);
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            name = value;
        }
    }
    public double BaseHealth { get; private set; }
    public double Health { get; set; }
    public double BaseArmor { get; private set; }
    public double Armor { get; set; }
    public double AbilityPoints { get; private set; }
    public Bag Bag { get; private set; }
    public Faction Faction { get; private set; }    
    public bool IsAlive { get; set; }
    public virtual double RestHealMultiplier { get; protected set; } 
}

