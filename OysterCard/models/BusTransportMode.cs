namespace OysterCard.models;

public class BusTransportMode : ITransportMode
{
    public decimal CalculateFare(Location source, Location? destination)
    {
        return Constants.BUS_FARE;
    }
}