public class Engine
{
    public string Model { get; private set; }
    public int Power { get; private set; }
    public int Displacement { get; private set; }
    public string Efficency { get; private set; }

    public Engine(string[] engineInfo)
    {
        Model = engineInfo[0];
        Power = int.Parse(engineInfo[1]);
        ParseOptionalFields(engineInfo);
    }

    private void ParseOptionalFields(string[] engineInfo)
    {
        if (engineInfo.Length == 3)
        {
            int displacement;

            int.TryParse(engineInfo[2], out displacement);

            if (displacement != 0)
            {
                Displacement = int.Parse(engineInfo[2]);
            }
            else
            {
                Efficency = engineInfo[2];
            }
        }
        else if (engineInfo.Length == 4)
        {
            Displacement = int.Parse(engineInfo[2]);
            Efficency = engineInfo[3];
        }
    }

    public void PrintEngine()
    {
        System.Console.WriteLine($"  {Model}:");
        System.Console.WriteLine($"    Power: {Power}");

        if(Displacement == 0)
            System.Console.WriteLine("    Displacement: n/a");
        else
            System.Console.WriteLine($"    Displacement: {Displacement}");

        if (Efficency == null)
            System.Console.WriteLine($"    Efficiency: n/a");
        else
            System.Console.WriteLine($"    Efficiency: {Efficency}");
    }
}

