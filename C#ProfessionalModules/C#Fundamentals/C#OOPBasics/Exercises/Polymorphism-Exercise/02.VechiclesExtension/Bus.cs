using System;

public class Bus : Vehicle, IBus 
{
    private const double CONSUMPTION_INCREASE = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {

    }

    public override void Drive(double distance)
    {
        double totalFuelConsumed = distance * (this.FuelConsumption);

        if (this.FuelQuantity < totalFuelConsumed)
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
        else
        {
            Console.WriteLine($"{this.GetType()} travelled {distance} km");

            this.FuelQuantity -= totalFuelConsumed;
        }
    }

    public void DriveWithPeople(double distance)
    {
        double totalFuelConsumed = distance * (this.FuelConsumption + CONSUMPTION_INCREASE);

        if (this.FuelQuantity < totalFuelConsumed)
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
        else
        {
            Console.WriteLine($"{this.GetType()} travelled {distance} km");

            this.FuelQuantity -= totalFuelConsumed;
        }
    }

    public override void Refuel(double amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (this.FuelQuantity + amount > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {amount} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += amount;
        }
    }
}

