namespace OysterCard;

public static class Constants
{
    public static readonly decimal INTRA_ZONE_FARE_WITHIN_ZONE_ONE = (decimal)2.50;
    public static readonly decimal INTRA_ZONE_FARE_OUTSIDE_ZONE_ONE = (decimal)2.00;
    public static readonly decimal INTER_ZONE_FARE_THROUGH_ZONE_ONE = (decimal)3.00;
    public static readonly decimal INTER_ZONE_FARE_OUTSIDE_ZONE_ONE = (decimal)2.25;
    public static readonly decimal INTER_ZONE_FARE_MORE_THAN_TWO_ZONES = (decimal)3.20;
    public static readonly decimal BUS_FARE = (decimal)1.80;
    public static readonly decimal MAX_FARE = INTER_ZONE_FARE_MORE_THAN_TWO_ZONES;
}