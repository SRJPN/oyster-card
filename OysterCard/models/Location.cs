namespace OysterCard.models
{
    public class Location
    {
        const decimal MAX_FARE = (decimal)3.20;
        private readonly Zone zone;
        private readonly string name;
        public Location(string name, Zone zone)
        {
            this.name = name;
            this.zone = zone;
        }

        public decimal CalculateFare(Location? destination)
        {
            if (destination == null)
                return MAX_FARE;
            return zone.CalculateFare(destination.zone);
        }
    }
}