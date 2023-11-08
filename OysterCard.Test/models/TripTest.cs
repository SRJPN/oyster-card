using Moq;
using OysterCard.models;

namespace OysterCard.Test.models
{
    public class TripTest
    {
        [Fact]
        public void Fare_should_calculate_MAX_FARE_if_destination_location_is_not_set()
        {
            var trip = new Trip(new Location("some-location", Zone.ONE));

            Assert.Equal((decimal)3.20, trip.CalculateFare());
        }

        [Fact]
        public void Fare_should_calculate_fare_between_locations()
        {
            var trip = new Trip(new Location("some-location", Zone.ONE));
            trip.SetDestination(new Location("destination-location", Zone.ONE));

            Assert.Equal((decimal)2.50, trip.CalculateFare());
        }
    }
}