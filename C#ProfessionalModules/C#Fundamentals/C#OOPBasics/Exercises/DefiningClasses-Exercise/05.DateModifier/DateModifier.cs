using System;

public class DateModifier
{
    double differenceInDays;

    public double DifferenceInDays
    {
        get { return differenceInDays; }
        set { differenceInDays = value; }
    }

    public double CalculateDifference(string date1, string date2)
    {
        DateTime parsedDate1 = DateTime.Parse(date1);
        DateTime parsedDate2 = DateTime.Parse(date2);

        differenceInDays = Math.Abs((parsedDate1 - parsedDate2).TotalDays);

        return differenceInDays;
    }
}

