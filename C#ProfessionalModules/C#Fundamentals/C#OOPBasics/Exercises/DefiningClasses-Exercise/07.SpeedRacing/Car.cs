public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumption, double distanceTraveled)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumption = fuelConsumption;
        DistanceTraveled = distanceTraveled;
    }

    public bool CanMove(double distanceToDrive)
    {
        if(distanceToDrive * FuelConsumption <= FuelAmount)
        {
            return true;
        }

        return false;
    }

    public void DriveCar(double distanceToDrive)
    {
        FuelAmount -= (distanceToDrive * FuelConsumption);
        DistanceTraveled += distanceToDrive;
    }

    public void PrintCar()
    {
        System.Console.WriteLine($"{Model} {FuelAmount:f2} {DistanceTraveled}");
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set { fuelAmount = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        private set { fuelConsumption = value; }
    }

    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        private set { distanceTraveled = value; }
    }

}

