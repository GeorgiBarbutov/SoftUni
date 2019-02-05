public class Engine
{
    private int engineSpeed;
    private int enginePower;

    public Engine(int engineSpeed, int enginePower)
    {
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
    }

    public int EngineSpeed
    {
        get { return engineSpeed; }
        private set { engineSpeed = value; }
    }

    public int EnginePower
    {
        get { return enginePower; }
        private set { enginePower = value; }
    }
}

