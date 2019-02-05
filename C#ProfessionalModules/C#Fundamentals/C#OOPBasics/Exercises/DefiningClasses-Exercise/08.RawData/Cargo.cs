public class Cargo
{
    private int cargoWeight;
    private string cargoType;

    public Cargo(int cargoWeight, string cargoType)
    {
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }

    public int CargoWeight
    {
        get { return cargoWeight; }
        private set { cargoWeight = value; }
    }

    public string CargoType
    {
        get { return cargoType; }
        private set { cargoType = value; }
    }
}

