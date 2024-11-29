using ConsoleApp2.Models;

public class ParkingManager
{
    private ParkingGarage _garage;

    public ParkingManager(ParkingGarage garage)
    {
        _garage = garage;
    }

    // Exempel på en metod för att läsa in parkeringsdata från en fil
    public void LoadParkingData(string filePath)
    {
        // Ladda data från fil (t.ex. JSON, text eller annan dataformat)
        try
        {
            // Läs filinnehåll
            string data = File.ReadAllText(filePath);
            // Processa filinnehåll här (t.ex. deserialisera JSON, etc.)
            Console.WriteLine(data); // För nu kan vi bara skriva ut innehållet
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}
