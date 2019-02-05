﻿public abstract class Vehicle : IVehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelConsumption = fuelConsumption;
        this.FuelQuantity = fuelQuantity;
    }

    public abstract void Drive(double distance);
    public abstract void Refuel(double amount);

    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:f2}";
    }

    public double FuelQuantity { get; protected set; }
    public double FuelConsumption { get; protected set; }
}

