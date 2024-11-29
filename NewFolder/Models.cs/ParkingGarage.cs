using System;
using System.Collections.Generic;

public class ParkingGarage
{
    private List<ParkingSpot> parkingSpots;

    public ParkingGarage()
    {
        parkingSpots = new List<ParkingSpot>();
    }

    public void AddParkingSpot(ParkingSpot spot)
    {
        parkingSpots.Add(spot);
    }

    // Lägg till FindAvailableSpot-metod för att hitta en ledig parkeringsplats för ett fordon
    public ParkingSpot FindAvailableSpot(Vehicle vehicle)
    {
        foreach (var spot in parkingSpots)
        {
            if (spot.IsAvailable && spot.Size >= vehicle.Size)
            {
                return spot; // Returnera första lediga platsen som är tillräckligt stor
            }
        }
        return null; // Ingen ledig plats hittades
    }

    public void PrintStatus()
    {
        Console.WriteLine("┌──────┬────────────┬───────────────┬────────────────┬──────────────────┐");
        Console.WriteLine("│ Spot │ Status     │ License Plate │ Parking Time   │ Current Fee (CZK)│");
        Console.WriteLine("├──────┼────────────┼───────────────┼────────────────┼──────────────────┤");

        foreach (var spot in parkingSpots)
        {
            string status = spot.IsAvailable ? "Available" : "Occupied";
            string licensePlate = spot.ParkedVehicle?.LicensePlate ?? "N/A";

            // Kontrollera om parkingTime är null och formatera den om den inte är null
            string parkingTime = spot.ParkedVehicle?.ParkingTime.HasValue == true
                ? spot.ParkedVehicle.ParkingTime.Value.ToString("g")
                : "N/A";

            string fee = spot.ParkedVehicle != null ? spot.CalculateFee().ToString("F2") : "0.00";

            Console.WriteLine($"│ {spot.SpotNumber,-4} │ {status,-10} │ {licensePlate,-13} │ {parkingTime,-14} │ {fee,-16} │");
        }

        Console.WriteLine("└──────┴────────────┴───────────────┴────────────────┴──────────────────┘");
    }
}
