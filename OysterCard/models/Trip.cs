namespace OysterCard.models;

public class Trip
{
    private Location? destination;

    public ITransportMode TransportMode { get; }

    private readonly Location? origin;
    public Trip(ITransportMode transportMode, Location? origin = null)
    {
        TransportMode = transportMode;
        this.origin = origin;
    }

    public void SetDestination(Location destination)
    {
        this.destination = destination;
    }

    public decimal CalculateFare()
    {
        return TransportMode.CalculateFare(origin, destination);
    }

    public bool IsOnGoing()
    {
        return destination == null;
    }
}