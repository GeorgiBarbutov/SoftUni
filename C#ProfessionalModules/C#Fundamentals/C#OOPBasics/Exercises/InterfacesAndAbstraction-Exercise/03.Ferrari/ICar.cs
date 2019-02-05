public interface ICar
{
    string Model { get; }
    string DriverName { get; }

    string GasPedal();
    string Brakes();
}