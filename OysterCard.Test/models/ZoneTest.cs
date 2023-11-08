using OysterCard.models;

namespace OysterCard.Test.models
{
    public class ZoneTest
    {
        [Fact]
        public void CalculateFare_should_calculate_fare_within_zone_1()
        {
            Assert.Equal((decimal)2.50, Zone.ONE.CalculateFare(Zone.ONE));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_between_zones_outside_zone_1()
        {
            Assert.Equal((decimal)2.00, Zone.TWO.CalculateFare(Zone.TWO));
            Assert.Equal((decimal)2.00, Zone.THREE.CalculateFare(Zone.THREE));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_including_zone_1()
        {
            Assert.Equal((decimal)3.00, Zone.TWO.CalculateFare(Zone.ONE));
            Assert.Equal((decimal)3.00, Zone.ONE.CalculateFare(Zone.TWO));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_excluding_zone_1()
        {
            Assert.Equal((decimal)2.25, Zone.TWO.CalculateFare(Zone.THREE));
            Assert.Equal((decimal)2.25, Zone.THREE.CalculateFare(Zone.TWO));
        }

        [Fact]
        public void CalculateFare_should_calculate_fare_travel_through_multiple_zones()
        {
            Assert.Equal((decimal)3.2, Zone.ONE.CalculateFare(Zone.THREE));
            Assert.Equal((decimal)3.2, Zone.THREE.CalculateFare(Zone.ONE));
        }
    }
}