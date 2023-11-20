using OysterCard.models;

namespace OysterCard.Test.models
{
    public class TripTest
    {
        [Fact]
        public void Fare_should_calculate_BUS_FARE_if_mode_of_transport_is_bus()
        {
            var trip = new Trip(new BusTransportMode(), new Location("some-location", Zone.ONE));

            Assert.Equal(Constants.BUS_FARE, trip.CalculateFare());
        }
        [Fact]
        public void Fare_should_calculate_MAX_FARE_if_destination_location_is_not_set()
        {
            var trip = new Trip(new TubeTransportMode(), new Location("some-location", Zone.ONE));

            Assert.Equal((decimal)3.20, trip.CalculateFare());
        }

        [Fact]
        public void Fare_should_calculate_fare_between_locations()
        {
            var trip = new Trip(new TubeTransportMode(), new Location("some-location", Zone.ONE));
            trip.SetDestination(new Location("destination-location", Zone.ONE));

            Assert.Equal((decimal)2.50, trip.CalculateFare());
        }

        [Fact]
        public void Ctor_should_initialise_without_location()
        {
            var trip = new Trip(new TubeTransportMode());

            Assert.NotNull(trip);
        }

        [Fact]
        public void IsOnGoing_should_return_true_for_destination_null()
        {
            var trip = new Trip(new TubeTransportMode());

            Assert.True(trip.IsOnGoing());
        }
    }
}