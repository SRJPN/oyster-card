using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard.Test.handlers;

public class StationEntryHandlerTest
{
    private readonly StationEntryHandler handler;
    private readonly Card card;

    public StationEntryHandlerTest()
    {
        handler = new StationEntryHandler();
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
    public void Execute_should_start_a_trip_with_given_location()
    {
        handler.Execute(card, "TUBE", "Hammersmith");
        Assert.Equal((decimal)26.8, card.GetBalance());
    }
}