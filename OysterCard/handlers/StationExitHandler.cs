using OysterCard.models;

namespace OysterCard.handlers;

public class StationExitHandler : ICommandHandler
{
    public string Execute(Card card, params string[] args)
    {
        var locationName = args[0];
        var location = Location.LOCATIONS.FirstOrDefault(x => x.Name == locationName) ?? throw new Exception($"Invalid location: {locationName}");
        card.EndLastTrip(location);
        return string.Empty;
    }
}