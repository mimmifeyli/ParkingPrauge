public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public DateTime? ParkingTime { get; set; } // Nullable DateTime
    public abstract int Size { get; }
}
