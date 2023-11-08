
namespace OysterCard.models;

public class Card
{
    private readonly Wallet wallet;
    private readonly IList<Trip> trips = new List<Trip>();

    public Card(Wallet wallet)
    {
        this.wallet = wallet;
    }

    public void StartTrip(TransportMode transportMode, Location location)
    {
        wallet.UseWallet(Constants.MAX_FARE);
        trips.Add(new Trip(transportMode, location));
    }

    public void EndLastTrip(Location destination)
    {
        var lastTrip = trips.Last();
        lastTrip.SetDestination(destination);
        wallet.Recharge(Constants.MAX_FARE);
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