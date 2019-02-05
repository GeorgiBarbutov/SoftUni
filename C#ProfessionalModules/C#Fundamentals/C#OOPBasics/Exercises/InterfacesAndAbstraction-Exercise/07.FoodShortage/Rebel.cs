public class Rebel : Human, IGroupable
{
    private const int AMOUNT_TO_BUY = 5;

    public Rebel(string name, int age, string group)
        : base(name, age)
    {
        this.Group = group;
    }

    public string Group { get; private set; }

    public override int BuyFood()
    {
        Food += AMOUNT_TO_BUY;

        return AMOUNT_TO_BUY;
    }
}

