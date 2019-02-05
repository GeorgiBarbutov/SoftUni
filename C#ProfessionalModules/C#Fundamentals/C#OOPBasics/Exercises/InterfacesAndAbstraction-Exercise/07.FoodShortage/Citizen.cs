public class Citizen : Human, IBirthable, IIdentifyable
{
    private const int AMOUNT_TO_BUY = 10;

    public Citizen(string name, int age, string id, string birthdate)
        : base(name, age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Birthdate { get; private set; }
    public string Id { get; private set; }

    public override int BuyFood()
    {
        Food += AMOUNT_TO_BUY;

        return AMOUNT_TO_BUY;
    }
}