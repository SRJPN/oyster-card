

namespace OysterCard.models;

public class Card
{
    private readonly Wallet wallet;
    private readonly IList<Trip> trips = new List<Trip>();

    public Card(Wallet wallet)
    {
        this.wallet = wallet;
    }

    public void StartTrip(ITransportMode transportMode, Location location)
    {
        var trip = new Trip(transportMode, location);
        wallet.UseWallet(trip.CalculateFare());
        trips.Add(trip);
    }

    public void EndLastTrip(Location destination)
    {
        var lastTrip = trips.Last();
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