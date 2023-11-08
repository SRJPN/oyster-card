namespace OysterCard.models;

public class Trip
{
    private Location? destination;
    private readonly Location source;
    public Trip(Location source)
    {
        this.source = source;
    }

    public void SetDestination(Location destination)
    {
        this.destination = destination;
    }

    public decimal CalculateFare() => source.CalculateFare(destination);
}