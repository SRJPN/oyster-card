namespace OysterCard.models
{
    public class Location
    {
        public static readonly IList<Location> LOCATIONS = new List<Location>() {
            new("Holborn", Zone.Zone_1),
            new("Aldgate", Zone.Zone_1),
            new("Earl’s Court", Zone.Zone_1),
            new("Hammersmith", Zone.Zone_2),
            new("Arsenal", Zone.Zone_2),
            new("Wimbledon", Zone.Zone_3),
        };
        public string Name { get; }

        const decimal MAX_FARE = (decimal)3.20;
        private readonly Zone zone;
        public Location(string name, Zone zone)
        {
            this.Name = name;
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