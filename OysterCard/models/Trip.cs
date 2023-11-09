namespace OysterCard.models;

public class Trip
{
    private Location? destination;

    public TransportMode TransportMode { get; }

    private readonly Location origin;
    public Trip(TransportMode transportMode, Location origin)
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
        if (TransportMode == TransportMode.BUS)
            return Constants.BUS_FARE;
        return origin.CalculateFare(destination);
    }
}