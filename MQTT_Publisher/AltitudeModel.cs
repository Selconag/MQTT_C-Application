using System.Text.Json;
using System.Text.Json.Serialization;

public class AltitudeModel
{
    public string Time { get; init; }
    public int Altitude { get; init; }
    public string DisplayText => $"Plane was at altitude {Altitude} ft. at {Time}.";
    // Constructor with parameters
    public AltitudeModel(string time, int altitude)
    {
        Time = time;
        Altitude = altitude;
    }
    // Static method to generate a random AltitudeModel
    internal static AltitudeModel GenerateRandomAltitudeModel()
    {
        // You can customize this method to generate values as needed
        Random random = new Random();
        string randomTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int randomAltitude = random.Next(10000, 40000);

        return new AltitudeModel(randomTime, randomAltitude);
    }

    // Method to serialize the object to JSON
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    // Static method to deserialize JSON to an AltitudeModel object
    public static AltitudeModel FromJson(string json)
    {
        return JsonSerializer.Deserialize<AltitudeModel>(json);
    }
}