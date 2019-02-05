public class Ferrari : ICar
{
    private const string MODEL = "488-Spider";

    public Ferrari(string name)
    {
        DriverName = name;
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{GasPedal()}/{DriverName}";
    }

    public string Model { get { return MODEL; } }

    public string DriverName { get; private set; }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }
}