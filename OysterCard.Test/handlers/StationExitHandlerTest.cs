using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard.Test.handlers;

public class StationExitHandlerTest
{
    private readonly StationExitHandler handler;
    private readonly Card card;

    public StationExitHandlerTest()
    {
        handler = new StationExitHandler();
        var wallet = new Wallet();
        wallet.Recharge(30);
        card = new Card(wallet);
    }

    [Fact]
    public void Execute_should_throw_error_if_invalid_station_name()
    {
        Assert.Throws<Exception>(() =>
        {
            handler.Execute(card, "TUBE", "invalid_station");
        });
    }

    [Fact]
    public void Execute_should_end_a_trip_with_given_location()
    {
        card.StartTrip(new Location("Hammersmith", Zone.TWO));
        handler.Execute(card, "Hammersmith");
        Assert.Equal((decimal)28.0, card.GetBalance());
    }
}