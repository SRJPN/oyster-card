using OysterCard.models;

namespace OysterCard.Test.models
{
    public class TubeTransportModeTest
    {
        private readonly TubeTransportMode transportMode;
        private readonly Location zone_one_location = new("zone-one-location", Zone.ONE);
        private readonly Location zone_two_location = new("zone-two-location", Zone.TWO);
        private readonly Location zone_three_location = new("zone-two-location", Zone.THREE);

        public TubeTransportModeTest()
        {
            transportMode = new TubeTransportMode();
        }

            [Fact]
        public void CalculateFare_should_return_MAX_FARE_if_destination_is_null()
        {
            Assert.Equal(Constants.MAX_FARE, transportMode.CalculateFare(zone_one_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_within_zone_1()
        {
            Assert.Equal((decimal)2.50, transportMode.CalculateFare(zone_one_location, zone_one_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_between_zones_outside_zone_1()
        {
            Assert.Equal((decimal)2.00, transportMode.CalculateFare(zone_two_location, zone_two_location));
            Assert.Equal((decimal)2.00, transportMode.CalculateFare(zone_three_location, zone_three_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_including_zone_1()
        {
            Assert.Equal((decimal)3.00, transportMode.CalculateFare(zone_two_location, zone_one_location));
            Assert.Equal((decimal)3.00, transportMode.CalculateFare(zone_one_location, zone_two_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_excluding_zone_1()
        {
            Assert.Equal((decimal)2.25, transportMode.CalculateFare(zone_two_location, zone_three_location));
            Assert.Equal((decimal)2.25, transportMode.CalculateFare(zone_three_location, zone_two_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_through_multiple_zones()
        {
            Assert.Equal((decimal)3.2, transportMode.CalculateFare(zone_one_location, zone_three_location));
            Assert.Equal((decimal)3.2, transportMode.CalculateFare(zone_three_location, zone_one_location));
        }
    }
}