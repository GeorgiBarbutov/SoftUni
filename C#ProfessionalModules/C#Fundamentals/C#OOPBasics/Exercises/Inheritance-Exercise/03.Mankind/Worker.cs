using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal hoursPerday;

    public Worker(string workerFirstName, string workerSecondName, decimal workerWeekSalary, decimal workerHoursPerday)
        :base(workerFirstName, workerSecondName)
    {
        WeekSalary = workerWeekSalary;
        HoursPerday = workerHoursPerday;
    }

    public override string ToString()
    {
        return $"First Name: {base.FirstName}" + Environment.NewLine +
            $"Last Name: {base.SecondName}" + Environment.NewLine +
            $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
            $"Hours per day: {this.HoursPerday:f2}" + Environment.NewLine +
            $"Salary per hour: {this.SalaryPerHour:f2}";
    }

    private decimal SalaryPerHour
    {
        get
        {
            return weekSalary / (hoursPerday * 5);
        }
    }

    private decimal WeekSalary
    {
        get { return weekSalary; }

        set
        {
            if (value <= 10)
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");

            weekSalary = value;
        }
    }

    private decimal HoursPerday
    {
        get { return hoursPerday; }

        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");

            hoursPerday = value;
        }
    }
}