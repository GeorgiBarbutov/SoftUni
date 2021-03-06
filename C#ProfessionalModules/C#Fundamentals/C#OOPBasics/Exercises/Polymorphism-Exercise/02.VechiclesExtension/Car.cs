﻿using System;

public class Car : Vehicle
{
    private const double SUMMER_CONSUMPTON_INCRESE = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {

    }

    public override void Drive(double distance)
    {
        double totalFuelConsumed = distance * (this.FuelConsumption + SUMMER_CONSUMPTON_INCRESE);

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
        if (amount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if(this.FuelQuantity + amount > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {amount} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += amount;
        }
    }
}

