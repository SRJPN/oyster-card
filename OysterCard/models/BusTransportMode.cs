namespace OysterCard.models;

public class BusTransportMode : ITransportMode
{
    public decimal CalculateFare(Location? source, Location? destination)
    {
        return Constants.BUS_FARE;
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return obj is BusTransportMode;
    }

    public override int GetHashCode()
    {
        return 1;
    }
}