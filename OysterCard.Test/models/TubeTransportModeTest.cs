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
            Assert.Equal(Constants.INTRA_ZONE_FARE_WITHIN_ZONE_ONE, transportMode.CalculateFare(zone_one_location, zone_one_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_between_zones_outside_zone_1()
        {
            Assert.Equal(Constants.INTRA_ZONE_FARE_OUTSIDE_ZONE_ONE, transportMode.CalculateFare(zone_two_location, zone_two_location));
            Assert.Equal(Constants.INTRA_ZONE_FARE_OUTSIDE_ZONE_ONE, transportMode.CalculateFare(zone_three_location, zone_three_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_including_zone_1()
        {
            Assert.Equal(Constants.INTER_ZONE_FARE_THROUGH_ZONE_ONE, transportMode.CalculateFare(zone_two_location, zone_one_location));
            Assert.Equal(Constants.INTER_ZONE_FARE_THROUGH_ZONE_ONE, transportMode.CalculateFare(zone_one_location, zone_two_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_excluding_zone_1()
        {
            Assert.Equal(Constants.INTER_ZONE_FARE_OUTSIDE_ZONE_ONE, transportMode.CalculateFare(zone_two_location, zone_three_location));
            Assert.Equal(Constants.INTER_ZONE_FARE_OUTSIDE_ZONE_ONE, transportMode.CalculateFare(zone_three_location, zone_two_location));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_through_multiple_zones()
        {
            Assert.Equal(Constants.INTER_ZONE_FARE_MORE_THAN_TWO_ZONES, transportMode.CalculateFare(zone_one_location, zone_three_location));
            Assert.Equal(Constants.INTER_ZONE_FARE_MORE_THAN_TWO_ZONES, transportMode.CalculateFare(zone_three_location, zone_one_location));
        }

        [Fact]
        public void CalculateFare_should_return_higher_fare_if_location_in_multiple_zones()
        {
            var location_in_multiple_zone = new Location("location_in_multiple_zone", Zone.ONE, Zone.TWO);
            Assert.Equal(Constants.INTER_ZONE_FARE_THROUGH_ZONE_ONE, transportMode.CalculateFare(zone_one_location, location_in_multiple_zone));
        }

        [Fact]
        public void CalculateFare_return_MAXFARE_if_source_location_is_null()
        {
            Assert.Equal(Constants.MAX_FARE, transportMode.CalculateFare(null, zone_one_location));
        }
    }
}