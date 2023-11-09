namespace OysterCard.models;

public class Location
{
    public static readonly IList<Location> LOCATIONS = new List<Location>() {
        new("Holborn", Zone.ONE),
        new("Aldgate", Zone.ONE),
        new("EarlsCourt", Zone.ONE),
        new("Hammersmith", Zone.TWO),
        new("Arsenal", Zone.TWO),
        new("Wimbledon", Zone.THREE),
    };
    public string Name { get; }
    public Zone Zone { get; }

    public Location(string name, Zone zone)
    {
        Name = name;
        Zone = zone;
    }
}