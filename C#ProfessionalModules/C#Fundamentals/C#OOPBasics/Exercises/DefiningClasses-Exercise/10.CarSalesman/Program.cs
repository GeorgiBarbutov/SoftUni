using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Engine> engineList = new List<Engine>();

        FillEngineList(n, engineList);

        int m = int.Parse(Console.ReadLine());

        List<Car> listOfCars = new List<Car>();
        FillCarList(engineList, m, listOfCars);

        foreach (var car in listOfCars)
        {
            car.PrintCar();
        }
    }

    private static void FillCarList(List<Engine> engineList, int m, List<Car> listOfCars)
    {
        for (int i = 0; i < m; i++)
        {
            string[] carInfo = Console.ReadLine().TrimEnd().Split(" ");

            string carModel = carInfo[0];
            Engine carEngine = engineList.FirstOrDefault(x => x.Model == carInfo[1]);
            int carWeight;
            string carColour;
            CreateOptional(carInfo, out carWeight, out carColour);

            Car car = new Car(carInfo[0], carEngine, carWeight, carColour);

            listOfCars.Add(car);
        }
    }

    private static void FillEngineList(int n, List<Engine> engineList)
    {
        for (int i = 0; i < n; i++)
        {
            string[] engineInfo = Console.ReadLine().TrimEnd().Split(" ");

            Engine engine = new Engine(engineInfo);

            engineList.Add(engine);
        }
    }

    private static void CreateOptional(string[] carInfo, out int carWeight, out string carColour)
    {
        carWeight = 0;
        carColour = "";
        if (carInfo.Length == 3)
        {
            int.TryParse(carInfo[2], out carWeight);

            if (carWeight != 0)
            {
                carWeight = int.Parse(carInfo[2]);
            }
            else
            {
                carColour = carInfo[2];
            }
        }
        else if (carInfo.Length == 4)
        {
            carWeight = int.Parse(carInfo[2]);
            carColour = carInfo[3];
        }
    }
}

