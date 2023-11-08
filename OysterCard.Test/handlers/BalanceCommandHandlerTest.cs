using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard.Test.handlers
{
    public class BalanceCommandHandlerTest
    {
        [Fact]
        public void Execute_should_return_balance_in_wallet()
        {
            var handler = new BalanceCommandHandler();
            var wallet = new Wallet();
            wallet.Recharge((decimal)50.50);
            var card = new Card(wallet);
            Assert.Equal("50.50", handler.Execute(card));
        }
    }
}