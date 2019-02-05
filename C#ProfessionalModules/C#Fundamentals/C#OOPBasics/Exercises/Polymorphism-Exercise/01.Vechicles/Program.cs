using System;

class Program
{
    static void Main(string[] args)
    {
        CreateCarAndTruck(out Car car, out Truck truck);
        DriveAndRefuel(car, truck);
        Print(car, truck);
    }

    private static void Print(Car car, Truck truck)
    {
        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void DriveAndRefuel(Car car, Truck truck)
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
                if (commandParams[1] == "Truck")
                {
                    truck.Drive(double.Parse(commandParams[2]));
                }
            }
            else if (commandParams[0] == "Refuel")
            {
                if (commandParams[1] == "Car")
                {
                    car.Refuel(double.Parse(commandParams[2]));
                }
                if (commandParams[1] == "Truck")
                {
                    truck.Refuel(double.Parse(commandParams[2]));
                }
            }
        }
    }

    private static void CreateCarAndTruck(out Car car, out Truck truck)
    {
        string[] carInfo = Console.ReadLine().Split(' ');
        string[] truckInfo = Console.ReadLine().Split(' ');

        car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
    }
}

