namespace OysterCard.models;

public interface ITransportMode
{
    public decimal CalculateFare(Location? source, Location? destination);
}
