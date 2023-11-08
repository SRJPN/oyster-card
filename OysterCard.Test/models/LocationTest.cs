using OysterCard.models;

namespace OysterCard.Test.models
{
    public class LocationTest
    {
        [Fact]
        public void CalculateFare_should_return_MAX_FARE_on_destination_null()
        {
            var location = new Location("some-location", Zone.ONE);
            Assert.Equal((decimal)3.20, location.CalculateFare(null));
        }
    }
}