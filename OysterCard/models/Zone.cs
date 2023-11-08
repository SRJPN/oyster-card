namespace OysterCard.models;

public enum Zone
{
    ONE,
    TWO,
    THREE
}


public static class ZoneMethods
{

    public static decimal CalculateFare(this Zone z1, Zone z2)
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
}