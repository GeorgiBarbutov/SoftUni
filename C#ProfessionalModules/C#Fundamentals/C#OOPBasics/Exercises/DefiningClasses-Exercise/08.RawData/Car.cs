public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tires;
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        private set { engine = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        private set { cargo = value; }
    }

    public Tire[] Tires
    {
        get { return tires; }
        private set { tires = value; }
    }

}

