using System.Collections.Generic;

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private int socketNumber;
    private Rarity rarity;
    private IGem[] gems;
    private int strength;
    private int agility;
    private int vitality;

    protected Weapon(string name, Rarity rarity, int minDamage, int maxDamage, int socketNumber)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.SocketNumber = socketNumber;

        this.Gems = new IGem[socketNumber];

        this.Strngth = 0;
        this.Agility = 0;
        this.Vitality = 0;

        IncreaseDamageInitial();
    }

    public void AddGem(IGem gem, int index)
    {
        if(index >= 0 && index < this.SocketNumber)
        {
            this.gems[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if(!(index < 0 || index >= this.SocketNumber || this.gems[index] == null))
        {
            this.gems[index] = null;
        }
    }

    private void IncreaseDamageInitial()
    {
        this.MinDamage *= (int)rarity;
        this.MaxDamage *= (int)rarity;
    }

    private void CalculateStats()
    {
        IncreaseMagicStats();
        IncreaseDamageStats();
    }

    private void IncreaseDamageStats()
    {
        this.MinDamage += this.Strngth * 2 + this.Agility * 1;
        this.MaxDamage += this.Strngth * 3 + this.Agility * 4;
    }

    private void IncreaseMagicStats()
    {
        for (int i = 0; i < this.SocketNumber; i++)
        {
            if (this.gems[i] != null)
            {
                this.Strngth += this.gems[i].StrenghtBonus;
                this.Agility += this.gems[i].AgilityBonus;
                this.Vitality += this.gems[i].VitalityBonus;
            }
        }
    }

    public override string ToString()
    {
        CalculateStats();

        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strngth} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }

    public int Vitality
    {
        get { return vitality; }
        private set { vitality = value; }
    }

    public int Agility
    {
        get { return agility; }
        private set { agility = value; }
    }

    public int Strngth
    {
        get { return strength; }
        private set { strength = value; }
    }

    public IReadOnlyCollection<IGem> Gems
    {
        get { return gems; }
        private set { gems = (IGem[])value; }
    }

    public Rarity Rarity
    {
        get { return rarity; }
        private set { rarity = value; }
    }

    public int SocketNumber
    {
        get { return socketNumber; }
        private set { socketNumber = value; }
    }

    public int MaxDamage
    {
        get { return maxDamage; }
        private set { maxDamage = value; }
    }
    public int MinDamage
    {
        get { return minDamage; }
        private set { minDamage = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

}

