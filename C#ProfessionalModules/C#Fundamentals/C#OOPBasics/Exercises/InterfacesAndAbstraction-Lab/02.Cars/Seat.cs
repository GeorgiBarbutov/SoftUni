using System;

public class Seat : ICar
{
    public string Model { get; private set; }
    public string Colour { get; private set; }

    public Seat(string model, string colour)
    {
        Model = model;
        Colour = colour;
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
        return $"{Model} {GetType().Name} {Colour}" + Environment.NewLine +
            Start() + Environment.NewLine +
            Stop();
    }
}