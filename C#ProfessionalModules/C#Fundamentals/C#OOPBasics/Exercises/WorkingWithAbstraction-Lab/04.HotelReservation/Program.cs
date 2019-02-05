using System;

class Program
{
    static void Main(string[] args)
    {
        string[] reservationInfo = Console.ReadLine().Split(' ');

        PrizeCalculator.CalculatePrize(reservationInfo);

        string a = Discount.None.ToString();
    }
}

