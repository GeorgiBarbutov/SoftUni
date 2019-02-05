using System;

class Program
{
    static void Main(string[] args)
    {
        CreateCarTruckAndBus(out Car car, out Truck truck, out Bus bus);
        DriveAndRefuel(car, truck, bus);
        Print(car, truck, bus);
    }

    private static void Print(Car car, Truck truck, Bus bus)
    {
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void DriveAndRefuel(Car car, Truck truck, Bus bus)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commandParams = Console.ReadLine().Split(' ');

            if (commandParams[0] == "Drive")
            {
                if (commandParams[1] == "Car")
                {
                    car.Drive(double.Parse(commandParams[2]));
                }
                else if (commandParams[1] == "Truck")
                {
                    truck.Drive(double.Parse(commandParams[2]));
                }
                else if (commandParams[1] == "Bus")
                {
                    bus.DriveWithPeople(double.Parse(commandParams[2]));
                }
            }
            else if(commandParams[0] == "DriveEmpty")
            {
                bus.Drive(double.Parse(commandParams[2]));
            }
            else if (commandParams[0] == "Refuel")
            {
                if (commandParams[1] == "Car")
                {
                    car.Refuel(double.Parse(commandParams[2]));
                }
                else if (commandParams[1] == "Truck")
                {
                    truck.Refuel(double.Parse(commandParams[2]));
                }
                else if (commandParams[1] == "Bus")
                {
                    bus.Refuel(double.Parse(commandParams[2]));
                }
            }
        }
    }

    private static void CreateCarTruckAndBus(out Car car, out Truck truck, out Bus bus)
    {
        car = null;
        truck = null;
        bus = null;

        for (int i = 0; i < 3; i++)
        {
            string[] vehicleInfo = Console.ReadLine().Split(' ');

            if(vehicleInfo[0] == "Car")
            {
                car = new Car(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
            }
            else if(vehicleInfo[0] == "Truck")
            {
                truck = new Truck(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
            }
            else if (vehicleInfo[0] == "Bus")
            {
                bus = new Bus(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
            }
        }
    }
}

