namespace OysterCard.models;

public class TubeTransportMode : ITransportMode
{
    public decimal CalculateFare(Location? source = null, Location? destination = null)
    {
        if (destination is null || source is null)
            return Constants.MAX_FARE;
        var fares = new List<decimal>();
        foreach (var z1 in source.Zones)
        {
            foreach (var z2 in destination.Zones)
            {
                fares.Add(CalculateFare(z1, z2));
            }
        }
        return fares.Max();
    }

    private static decimal CalculateFare(Zone z1, Zone z2)
    {
        if (z1 - z2 == 0)
            if (z1 == Zone.ONE)
                return Constants.INTRA_ZONE_FARE_WITHIN_ZONE_ONE;
            else
                return Constants.INTRA_ZONE_FARE_OUTSIDE_ZONE_ONE;
        if (Math.Abs(z1 - z2) == 1)
            if (z1 == Zone.ONE || z2 == Zone.ONE)
                return Constants.INTER_ZONE_FARE_THROUGH_ZONE_ONE;
            else
                return Constants.INTER_ZONE_FARE_OUTSIDE_ZONE_ONE;
        return Constants.INTER_ZONE_FARE_MORE_THAN_TWO_ZONES;
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        return obj is TubeTransportMode;
    }

    public override int GetHashCode()
    {
        return 1;
    }
}
