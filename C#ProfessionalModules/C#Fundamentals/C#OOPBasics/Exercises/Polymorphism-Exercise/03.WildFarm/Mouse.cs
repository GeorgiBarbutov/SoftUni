public class Mouse : Mammal
{
    private const double WEIGHT_INCREASE = 0.10;
    private const string SOUND = "Squeak";

    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion, new string[2] { "Vegetable", "Fruit" }, WEIGHT_INCREASE)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine(SOUND);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

