using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] carParameters = Console.ReadLine().Split(' ');

            string carModule = carParameters[0];
            double carFuelAmount = double.Parse(carParameters[1]);
            double carFuelConsumption = double.Parse(carParameters[2]);
            double carDistanceTraveled = 0;

            Car newCar = new Car(carModule, carFuelAmount, carFuelConsumption, carDistanceTraveled);

            cars.Add(newCar);
        }

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string carModel = input.Split(' ')[1];
            double distanceToDrive = double.Parse(input.Split(' ')[2]);

            for (int i = 0; i < cars.Count; i++)
            {
                if(cars[i].Model == carModel)
                {
                    bool carCanMove = cars[i].CanMove(distanceToDrive);

                    if(carCanMove)
                    {
                        cars[i].DriveCar(distanceToDrive);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }

                    break;
                }
            }
        }

        foreach (var car in cars)
        {
            car.PrintCar();
        }
    }
}

