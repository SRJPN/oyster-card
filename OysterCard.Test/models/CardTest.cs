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

            card.StartTrip(new TubeTransportMode(), new Location("some-location", Zone.ONE));

            Assert.Equal((decimal)26.8, card.GetBalance());
        }

        [Fact]
        public void StartTrip_should_deduct_wallet_by_BUS_FARE_for_BUS_transport()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.StartTrip(new BusTransportMode(), new Location("some-location", Zone.ONE));

            Assert.Equal((decimal)28.2, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_should_end_last_trip_and_update_wallet_with_fare()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.StartTrip(new TubeTransportMode(), new Location("some-location", Zone.ONE));
            card.EndLastTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.ONE));

            Assert.Equal((decimal)27.5, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_should_end_last_trip_and_ignore_wallet_for_bus_transport()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.StartTrip(new BusTransportMode(), new Location("some-location", Zone.ONE));
            card.EndLastTrip(new BusTransportMode(), new Location("some-destination-location", Zone.ONE));

            Assert.Equal((decimal)28.2, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_charge_MAX_FARE_if_no_trips()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());

            card.EndLastTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.ONE));

            Assert.Equal((decimal)26.8, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_charge_MAX_FARE_if_no_ongoing_trips()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());
            card.StartTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.ONE));
            card.EndLastTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.ONE));

            card.EndLastTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.TWO));

            Assert.Equal((decimal)24.3, card.GetBalance());
        }

        [Fact]
        public void EndLastTrip_charge_MAX_FARE_if_no_ongoing_trips_in_same_mode_of_transport()
        {
            var wallet = new Wallet();
            wallet.Recharge(30);

            var card = new Card(wallet);
            Assert.Equal((decimal)30.0, card.GetBalance());
            card.StartTrip(new BusTransportMode(), new Location("some-origin-location", Zone.ONE));

            card.EndLastTrip(new TubeTransportMode(), new Location("some-destination-location", Zone.TWO));

            Assert.Equal((decimal)25.0, card.GetBalance());
        }
    }
}