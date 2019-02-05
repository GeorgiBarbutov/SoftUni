public class Cat : Feline
{
    private const double WEIGHT_INCREASE = 0.30;
    private const string SOUND = "Meow";

    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed, new string[2] { "Vegetable", "Meat" }, WEIGHT_INCREASE)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine(SOUND);
    }
}

