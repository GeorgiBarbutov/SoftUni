public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    string[] FoodEatenTypes { get; }
    double WeightIncrease { get; }
    int FoodEaten { get; }

    void MakeSound();
    void Eat(Food food);
}