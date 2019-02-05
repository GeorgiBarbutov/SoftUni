using System;

public class Topping
{
    const int CALORIES_PER_GRAM = 2;

    private string type;
    private double weight;
    private double totalCalories;

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;

        CalculateTotalCalories();
    }

    private void CalculateTotalCalories()
    {
        double typeModifier = SetModifier();

        TotalCalories = (CALORIES_PER_GRAM * Weight) * typeModifier;
    }

    private double SetModifier()
    {
        if (Type == "Meat")
            return 1.2;
        else if (Type == "Veggies")
            return 0.8;
        else if (Type == "Cheese")
            return 1.1;
        else if (Type == "Sauce")
            return 0.9;

        return 1.0;
    }

    public double TotalCalories
    {
        get { return totalCalories; }
        private set { totalCalories = value; }
    }

    private double Weight
    {
        get { return weight; }

        set
        {
            if (value < 1 || value > 50)
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");

            weight = value;
        }
    }

    private string Type
    {
        get { return type; }

        set
        {
            if (!(value == "Meat" || value == "Veggies" || value == "Cheese" || value == "Sauce"))
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");

            type = value;
        }
    }
}

