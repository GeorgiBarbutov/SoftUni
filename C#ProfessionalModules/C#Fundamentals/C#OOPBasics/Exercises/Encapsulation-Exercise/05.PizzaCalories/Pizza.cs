using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private double totalCalories;

    private Pizza()
    {
        Toppings = new List<Topping>();
    }

    public Pizza(string name, Dough dough) : this()
    {
        Name = name;
        Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (GetNumberOfToppings() == 10)
            throw new ArgumentException("Number of toppings should be in range [0..10].");

        Toppings.Add(topping);
    }

    public int GetNumberOfToppings()
    {
        return Toppings.Count;
    }

    public double GetTotalCalories()
    {
        double calories = CalculateTotalCalories();

        return calories;
    }

    private double CalculateTotalCalories()
    {
        double result = Dough.TotalCalories;

        foreach (var topping in Toppings)
        {
            result += topping.TotalCalories;
        }

        return result;
    }

    private double TotalCalories
    {
        get { return totalCalories; }
        set { totalCalories = value; }
    }

    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public string Name
    {
        get { return name; }

        private set
        {
            if (String.IsNullOrEmpty(value) || value.Length > 15)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

            name = value;
        }
    }
}

