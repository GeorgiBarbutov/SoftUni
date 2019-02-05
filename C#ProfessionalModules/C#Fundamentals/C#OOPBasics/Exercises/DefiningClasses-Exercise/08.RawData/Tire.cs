public class Tire
{
    private double tirePressure;
    private int tireAge;

    public Tire(double tirePressure, int tireAge)
    {
        TirePressure = tirePressure;
        TireAge = tireAge;
    }

    public double TirePressure
    {
        get { return tirePressure; }
        private set { tirePressure = value; }
    }

    public int TireAge
    {
        get { return tireAge; }
        private set { tireAge = value; }
    }

}

