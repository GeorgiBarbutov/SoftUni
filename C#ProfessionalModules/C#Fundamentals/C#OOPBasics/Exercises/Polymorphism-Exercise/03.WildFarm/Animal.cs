using System.Linq;

public abstract class Animal : IAnimal
{
    public Animal(string name, double weight, string[] foodEatenTypes, double weightIncrease)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEatenTypes = foodEatenTypes;
        this.WeightIncrease = weightIncrease;

        this.FoodEaten = 0;

        MakeSound();
    }

    public abstract void MakeSound();

    public void Eat(Food food)
    {
        if(this.FoodEatenTypes.Contains(food.Type))
        {
            this.Weight += food.Quantity * WeightIncrease;
            this.FoodEaten += food.Quantity;
        }
        else
        {
            System.Console.WriteLine($"{this.GetType().Name} does not eat {food.Type}!");
        }
    }

    public string Name { get; private set; }
    public double Weight { get; private set; }
    public string[] FoodEatenTypes { get; private set; }
    public double WeightIncrease { get; private set; }
    public int FoodEaten { get; private set; }
}

