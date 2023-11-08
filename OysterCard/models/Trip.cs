namespace OysterCard.models;

public class Trip
{
    private Location? destination;
    private readonly TransportMode transportMode;
    private readonly Location origin;
    public Trip(TransportMode transportMode, Location origin)
    {
        this.transportMode = transportMode;
        this.origin = origin;
    }

    public void SetDestination(Location destination)
    {
        this.destination = destination;
    }

    public decimal CalculateFare()
    {
        if (transportMode == TransportMode.BUS)
            return Constants.BUS_FARE;
        return origin.CalculateFare(destination);
    }
}