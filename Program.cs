using System;
using ConsoleApp2.Models;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ut ASCII-konst
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"  
______                            ______          _    _                      _____  
| ___ \                           | ___ \        | |  (_)                    / __  \ 
| |_/ / __ __ _  __ _ _   _  ___  | |_/ /_ _ _ __| | ___ _ __   __ _  __   __`' / /' 
|  __/ '__/ _` |/ _` | | | |/ _ \ |  __/ _` | '__| |/ / | '_ \ / _` | \ \ / /  / /   
| |  | | | (_| | (_| | |_| |  __/ | | | (_| | |  |   <| | | | | (_| |  \ V / ./ /___ 
\_|  |_|  \__,_|\__, |\__,_|\___| \_|  \__,_|_|  |_|\_\_|_| |_|\__, |   \_/  \_____/ 
                 __/ |                                          __/ |                
                |___/                                          |___/                  ");
            Console.ResetColor();

            // Skapa parkeringsgarage
            ParkingGarage garage = new ParkingGarage();

            // Skapa några parkeringsplatser (spotnummer och storlek)
            garage.AddParkingSpot(new ParkingSpot(1, 2));  // Plats 1, storlek 2
            garage.AddParkingSpot(new ParkingSpot(2, 1));  // Plats 2, storlek 1
            garage.AddParkingSpot(new ParkingSpot(3, 3));  // Plats 3, storlek 3

            // Skapa fordon
            Vehicle car = new Car { LicensePlate = "ABC123" };
            Vehicle bus = new Bus { LicensePlate = "BUS456" };
            Vehicle motorbike = new Motorbike { LicensePlate = "MOTO789" };

            // Försök att parkera fordon
            ParkingSpot carSpot = garage.FindAvailableSpot(car);
            ParkingSpot busSpot = garage.FindAvailableSpot(bus);
            ParkingSpot motorbikeSpot = garage.FindAvailableSpot(motorbike);

            // Skriv ut parkeringresultat
            Console.WriteLine($"Car parked at spot: {carSpot?.SpotNumber ?? 0}");
            Console.WriteLine($"Bus parked at spot: {busSpot?.SpotNumber ?? 0}");
            Console.WriteLine($"Motorbike parked at spot: {motorbikeSpot?.SpotNumber ?? 0}");

            // Visa parkeringsstatus
            garage.PrintStatus();
        }
    }
}
