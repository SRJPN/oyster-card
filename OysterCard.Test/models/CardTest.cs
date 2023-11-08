using OysterCard.models;

namespace OysterCard.Test.models
{
    public class CardTest
    {
        [Fact]
        public void Ctor_should_initialise_with_a_wallet()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());
        }

        [Fact]
        public void Recharge_should_recharge_wallet()
        {
            var wallet = new Wallet();
            var card = new Card(wallet);

            Assert.Equal(0, card.GetBalance());

            card.Recharge((decimal)30.0);
            Assert.Equal((decimal)30.0, card.GetBalance());
        }

        [Fact]
        public void StartTrip_should_deduct_wallet_by_MAX_FARE()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.StartTrip(TransportMode.TUBE, new Location("some-location", Zone.ONE));

            Assert.Equal((decimal)26.8, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_should_end_last_trip_and_update_wallet_with_fare()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.StartTrip(TransportMode.TUBE, new Location("some-location", Zone.ONE));
            card.EndLastTrip(new Location("some-destination-location", Zone.ONE));

            Assert.Equal((decimal)27.5, card.GetBalance());
        }
    }
}