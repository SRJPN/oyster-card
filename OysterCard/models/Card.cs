

namespace OysterCard.models;

public class Card
{
    private readonly Wallet wallet;
    private readonly IList<Trip> trips = new List<Trip>();

    public Card(Wallet wallet)
    {
        this.wallet = wallet;
    }

    public Trip StartTrip(ITransportMode transportMode, Location? location = null)
    {
        var trip = new Trip(transportMode, location);
        wallet.UseWallet(trip.CalculateFare());
        trips.Add(trip);
        return trip;
    }

    public void EndLastTrip(ITransportMode transportMode, Location destination)
    {
        var lastTrip = trips.LastOrDefault();
        if (lastTrip is null || !lastTrip.IsOnGoing() || !lastTrip.TransportMode.Equals(transportMode))
        {
            lastTrip = StartTrip(transportMode);
        }
        wallet.Recharge(lastTrip.CalculateFare());
        lastTrip.SetDestination(destination);
        wallet.UseWallet(lastTrip.CalculateFare());
    }

    public void Recharge(decimal amount)
    {
        wallet.Recharge(amount);
    }

    public decimal GetBalance()
    {
        return wallet.Balance;
    }
}