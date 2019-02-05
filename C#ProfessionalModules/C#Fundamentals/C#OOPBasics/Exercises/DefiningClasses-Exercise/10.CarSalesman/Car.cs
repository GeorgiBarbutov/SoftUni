public class Car
{
    public string Model { get; private set; }
    public Engine Engine { get; private set; }
    public int Weight { get; private set; }
    public string Colour { get; private set; }

    public Car(string model, Engine engine, int weight, string colour)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Colour = colour;
    }

    public void PrintCar()
    {
        System.Console.WriteLine(Model + ":");
        Engine.PrintEngine();

        if (Weight == 0)
            System.Console.WriteLine($"  Weight: n/a");
        else
            System.Console.WriteLine($"  Weight: {Weight}");

        if (Colour == "")
            System.Console.WriteLine($"  Color: n/a");
        else
            System.Console.WriteLine($"  Color: {Colour}");
    }
}

