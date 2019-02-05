public abstract class Bird : Animal, IBird
{
    public Bird(string name, double weight, double wingSize, string[] foodEatenTypes, double weightIncrease) 
        : base(name, weight, foodEatenTypes, weightIncrease)
    {
        this.WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }

    public double WingSize { get; private set; }
}

