using System;

public class ParkingSpot
{
    public int SpotNumber { get; }
    public int Size { get; }  // Storlek på parkeringsplatsen
    public bool IsAvailable => ParkedVehicle == null;
    public Vehicle ParkedVehicle { get; private set; }

    // Uppdaterad konstruktor som tar både spotNumber och size
    public ParkingSpot(int spotNumber, int size)
    {
        SpotNumber = spotNumber;
        Size = size;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        if (IsAvailable)
        {
            ParkedVehicle = vehicle;
            vehicle.ParkingTime = DateTime.Now; // Sätt parkeringstiden
        }
        else
        {
            throw new InvalidOperationException("Parking spot is already occupied.");
        }
    }

    public void RemoveVehicle()
    {
        if (ParkedVehicle != null)
        {
            ParkedVehicle.ParkingTime = null; // Nollställ parkeringstiden
            ParkedVehicle = null;
        }
    }

    // Beräkna parkeringsavgift (om det behövs)
    public double CalculateFee()
    {
        if (ParkedVehicle == null || ParkedVehicle.ParkingTime == null)
            return 0.00; // Ingen avgift om inget fordon är parkerat

        // Exempel: Beräkna avgiften per timme (t.ex. 20 CZK per timme)
        double hourlyRate = 20.00;
        TimeSpan parkedDuration = DateTime.Now - ParkedVehicle.ParkingTime.Value;
        return Math.Max(parkedDuration.TotalHours * hourlyRate, 0); // Returnera beräknad avgift
    }
}
