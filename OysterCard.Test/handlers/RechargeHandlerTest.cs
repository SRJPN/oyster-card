using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard.Test.handlers;

public class RechargeHandlerTest
{
    [Fact]
    public void Execute_should_recharge_wallet_with_given_amount()
    {
        var handler = new RechargeHandler();
        var wallet = new Wallet();
        var card = new Card(wallet);

        handler.Execute(card, "30.00");

        Assert.Equal((decimal)30.00, card.GetBalance());
    }
}