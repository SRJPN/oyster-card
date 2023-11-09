namespace OysterCard.models;

public class TubeTransportMode : ITransportMode
{
    public decimal CalculateFare(Location source, Location? destination = null)
    {
        if (destination == null)
            return Constants.MAX_FARE;
        if (source.Zone - destination.Zone == 0)
            if (source.Zone == Zone.ONE)
                return Constants.INTRA_ZONE_FARE_WITHIN_ZONE_ONE;
            else
                return Constants.INTRA_ZONE_FARE_OUTSIDE_ZONE_ONE;
        if (Math.Abs(source.Zone - destination.Zone) == 1)
            if (source.Zone == Zone.ONE || destination.Zone == Zone.ONE)
                return Constants.INTER_ZONE_FARE_THROUGH_ZONE_ONE;
            else
                return Constants.INTER_ZONE_FARE_OUTSIDE_ZONE_ONE;
        return Constants.INTER_ZONE_FARE_MORE_THAN_TWO_ZONES;
    }
}
