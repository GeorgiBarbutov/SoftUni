public class Dog : Mammal
{
    private const double WEIGHT_INCREASE = 0.40;
    private const string SOUND = "Woof!";

    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion, new string[1] { "Meat" }, WEIGHT_INCREASE)
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

