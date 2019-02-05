public abstract class Gem : IGem
{
    private int strengthBonus;
    private int agilityBonus;
    private int vitalityBonus;
    private Clarity clarity;

    protected Gem(int strengthBonus, int agilityBonus, int vitalityBonus, Clarity clarity)
    {
        this.StrenghtBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.VitalityBonus = vitalityBonus;
        this.Clarity = clarity;

        IncreaseStats();
    }

    private void IncreaseStats()
    {
        this.StrenghtBonus += (int)this.Clarity;
        this.AgilityBonus += (int)this.Clarity;
        this.VitalityBonus += (int)this.Clarity;
    }

    public Clarity Clarity
    {
        get { return clarity; }
        private set { clarity = value; }
    }

    public int VitalityBonus
    {
        get { return vitalityBonus; }
        private set { vitalityBonus = value; }
    }

    public int AgilityBonus
    {
        get { return agilityBonus; }
        private set { agilityBonus = value; }
    }

    public int StrenghtBonus
    {
        get { return strengthBonus; }
        private set { strengthBonus = value; }
    }
}

