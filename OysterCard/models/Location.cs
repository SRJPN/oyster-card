namespace OysterCard.models;

public class Location
{
    public static readonly IList<Location> LOCATIONS = new List<Location>() {
        new("Holborn", Zone.ONE),
        new("Aldgate", Zone.ONE),
        new("Earl’s Court", Zone.ONE),
        new("Hammersmith", Zone.TWO),
        new("Arsenal", Zone.TWO),
        new("Wimbledon", Zone.THREE),
    };
    public string Name { get; }
    private readonly Zone zone;
    public Location(string name, Zone zone)
    {
        this.Name = name;
        this.zone = zone;
    }

    public decimal CalculateFare(Location? destination)
    {
        if (destination == null)
            return Constants.MAX_FARE;
        return zone.CalculateFare(destination.zone);
    }
}