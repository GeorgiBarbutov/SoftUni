public class Tiger : Feline
{
    private const double WEIGHT_INCREASE = 1.00;
    private const string SOUND = "ROAR!!!";

    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed, new string[1] { "Meat" }, WEIGHT_INCREASE)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine(SOUND);
    }
}

