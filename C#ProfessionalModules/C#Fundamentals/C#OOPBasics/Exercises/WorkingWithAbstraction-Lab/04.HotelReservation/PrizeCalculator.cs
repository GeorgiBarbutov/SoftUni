using System;

public static class PrizeCalculator
{
    public static void CalculatePrize(string[] reservationInfo)
    {
        double prizePerDay = double.Parse(reservationInfo[0]);
        int numberOfDays = int.Parse(reservationInfo[1]);
        int season = (int)Enum.Parse<Season>(reservationInfo[2]);
        int discount = 0;

        if (reservationInfo.Length == 4)
        {
            discount = (int)Enum.Parse<Discount>(reservationInfo[3]);
        }

        double totalPrize = (prizePerDay * numberOfDays * season) * ((100 - discount) / 100.0);
        Print(totalPrize);
    }

    private static void Print(double totalPrize)
    {
        Console.WriteLine($"{totalPrize:f2}");
    }
}

