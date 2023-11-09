using OysterCard.models;

namespace OysterCard.Test.models
{
    public class BusTransportModeTest
    {
        [Fact]
        public void CalculateFare_should_return_BUS_FARE()
        {
            var transportMode = new BusTransportMode();
            var fare = transportMode.CalculateFare(new Location("some-location", Zone.ONE), new Location("sone-other-location", Zone.ONE));
            Assert.Equal(Constants.BUS_FARE, fare);
        }
    }
}