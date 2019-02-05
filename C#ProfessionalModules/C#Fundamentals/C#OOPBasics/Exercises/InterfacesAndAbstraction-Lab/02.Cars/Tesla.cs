using System;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; private set; }
    public string Colour { get; private set; }
    public int Batery { get; private set; }

    public Tesla(string model, string colour, int batery)
    {
        Model = model;
        Colour = colour;
        Batery = batery;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{Model} {GetType().Name} {Colour} with {Batery} Batteries" + Environment.NewLine +
            Start() + Environment.NewLine +
            Stop();
    }
}