namespace OysterCard.models;

public class Location
{
    public static readonly IList<Location> LOCATIONS = new List<Location>() {
        new("Holborn", Zone.ONE),
        new("Aldgate", Zone.ONE),
        new("EarlsCourt", Zone.ONE, Zone.TWO),
        new("Hammersmith", Zone.TWO),
        new("Arsenal", Zone.TWO),
        new("Wimbledon", Zone.THREE),
    };
    public string Name { get; }
    public IReadOnlyList<Zone> Zones { get; }

    public Location(string name, params Zone[] zones)
    {
        Name = name;
        Zones = zones.ToList();
    }
}