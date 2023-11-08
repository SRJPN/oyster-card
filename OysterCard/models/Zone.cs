namespace OysterCard.models;

public enum Zone
{
    Zone_1,
    Zone_2,
    Zone_3
}


public static class ZoneMethods
{

    public static decimal CalculateFare(this Zone z1, Zone z2)
    {
        if (z1 == z2 && z1 == Zone.Zone_1)
            return (decimal)2.50;
        else if (z1 == z2 && z1 > Zone.Zone_1)
            return (decimal)2.00;
        else if (z1 != z2 && (z1 == Zone.Zone_1 || z2 == Zone.Zone_1))
            return (decimal)3.00;
        else if (z1 != z2 && z1 != Zone.Zone_1 && z2 != Zone.Zone_1)
            return (decimal)2.25;
        return 0;
    }
}