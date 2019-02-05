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

            string carModel = carParameters[0];
            int engineSpeed = int.Parse(carParameters[1]);
            int enginePower = int.Parse(carParameters[2]);
            int cargoWeight = int.Parse(carParameters[3]);
            string cargoType = carParameters[4];
            double tire1Pressure = double.Parse(carParameters[5]);
            int tire1Age = int.Parse(carParameters[6]);
            double tire2Pressure = double.Parse(carParameters[7]);
            int tire2Age = int.Parse(carParameters[8]);
            double tire3Pressure = double.Parse(carParameters[9]);
            int tire3Age = int.Parse(carParameters[10]);
            double tire4Pressure = double.Parse(carParameters[11]);
            int tire4Age = int.Parse(carParameters[12]);

            Engine newEngine = new Engine(engineSpeed, enginePower);
            Cargo newCargo = new Cargo(cargoWeight, cargoType);
            Tire tire1 = new Tire(tire1Pressure, tire1Age);
            Tire tire2 = new Tire(tire2Pressure, tire2Age);
            Tire tire3 = new Tire(tire3Pressure, tire3Age);
            Tire tire4 = new Tire(tire4Pressure, tire4Age);
            Tire[] newTires = new Tire[] { tire1, tire2, tire3, tire4 };

            Car newCar = new Car(carModel, newEngine, newCargo, newTires);

            cars.Add(newCar);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars)
            {
                if (car.Cargo.CargoType == "fragile")
                {
                    for (int i = 0; i < car.Tires.Length; i++)
                    {
                        if (car.Tires[i].TirePressure < 1.0)
                        {
                            Console.WriteLine(car.Model);

                            break;
                        }
                    }
                }
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in cars)
            {
                if(car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}

