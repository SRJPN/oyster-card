using OysterCard.models;

namespace OysterCard.Test.models
{
    public class WalletTest
    {
        [Fact]
        public void RechargeWallet_should_add_amount_to_wallet()
        {
            var wallet = new Wallet();
            wallet.Recharge(10);

            Assert.Equal(10, wallet.Balance);

            wallet.Recharge(15);

            Assert.Equal(25, wallet.Balance);
        }

        [Fact]
        public void UseWallet_should_deduct_amount_from_wallet()
        {
            var wallet = new Wallet();
            wallet.Recharge(20);
            wallet.UseWallet(5);

            Assert.Equal(15, wallet.Balance);
        }

        [Fact]
        public void UseWallet_should_throw_error_if_amount_is_greater_than_balance()
        {
            var wallet = new Wallet();
            Assert.Throws<Exception>(() =>
            {
                wallet.UseWallet(5);
            });


        }
    }
}