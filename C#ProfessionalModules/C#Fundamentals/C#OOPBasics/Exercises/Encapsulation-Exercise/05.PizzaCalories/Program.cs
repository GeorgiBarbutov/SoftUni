using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Pizza pizza = CreatePizza();
            AddToppings(pizza);
            Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    private static void AddToppings(Pizza pizza)
    {
        string[] toppingInput;

        while ((toppingInput = Console.ReadLine().Split(' '))[0] != "END")
        {
            string type = toppingInput[1].ToUpper().First() + toppingInput[1].ToLower().Substring(1);

            Topping topping = new Topping(type, double.Parse(toppingInput[2]));

            pizza.AddTopping(topping);
        }
    }

    private static Pizza CreatePizza()
    {
        string[] pizzaInput = Console.ReadLine().Split(' ');
        string pizzaName = pizzaInput[1];

        string[] doughtInput = Console.ReadLine().Split(' ');

        string flourType = doughtInput[1].ToUpper().First() + doughtInput[1].ToLower().Substring(1);
        string bakingTechnique = doughtInput[2].ToUpper().First() + doughtInput[2].ToLower().Substring(1);

        Dough dough = new Dough(flourType, bakingTechnique, double.Parse(doughtInput[3]));

        Pizza pizza = new Pizza(pizzaName, dough);
        return pizza;
    }
}

