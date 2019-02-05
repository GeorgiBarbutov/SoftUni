public class Hen : Bird
{
    private const double WEIGHT_INCREASE = 0.35;
    private const string SOUND = "Cluck";

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize, new string[4] { "Vegetable", "Fruit", "Meat", "Seeds" }, WEIGHT_INCREASE)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine(SOUND);
    }
}