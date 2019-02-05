public abstract class Feline : Mammal, IFeline
{
    public Feline(string name, double weight, string livingRegion, string breed, string[] foodEatenTypes, double weightIncrease) 
        : base(name, weight, livingRegion, foodEatenTypes, weightIncrease)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }

    public string Breed { get; private set; }
}

