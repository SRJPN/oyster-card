using OysterCard.models;

namespace OysterCard.Test.models
{
    public class ZoneTest
    {
        [Fact]
        public void CalculateFare_should_calculate_fare_within_zone_1()
        {
            Assert.Equal((decimal)2.50, Zone.Zone_1.CalculateFare(Zone.Zone_1));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_between_zones_outside_zone_1()
        {
            Assert.Equal((decimal)2.00, Zone.Zone_2.CalculateFare(Zone.Zone_2));
            Assert.Equal((decimal)2.00, Zone.Zone_3.CalculateFare(Zone.Zone_3));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_including_zone_1()
        {
            Assert.Equal((decimal)3.00, Zone.Zone_2.CalculateFare(Zone.Zone_1));
            Assert.Equal((decimal)3.00, Zone.Zone_1.CalculateFare(Zone.Zone_2));

            Assert.Equal((decimal)3.00, Zone.Zone_1.CalculateFare(Zone.Zone_3));
            Assert.Equal((decimal)3.00, Zone.Zone_3.CalculateFare(Zone.Zone_1));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_excluding_zone_1()
        {
            Assert.Equal((decimal)2.25, Zone.Zone_2.CalculateFare(Zone.Zone_3));
            Assert.Equal((decimal)2.25, Zone.Zone_3.CalculateFare(Zone.Zone_2));
        }
    }
}