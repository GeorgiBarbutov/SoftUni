public abstract class Mammal : Animal, IMammal
{
    public Mammal(string name, double weight, string livingRegion, string[] foodEatenTypes, double weightIncrease) 
        : base(name, weight, foodEatenTypes, weightIncrease)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }
}

