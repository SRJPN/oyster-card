using OysterCard.models;

namespace OysterCard.handlers;

public class StationEntryHandler : ICommandHandler
{
    public string Execute(Card card, params string[] args)
    {
        var modeOfTransport = args[0];
        var locationName = args[1];
        var location = Location.LOCATIONS.FirstOrDefault(x => x.Name == locationName) ?? throw new Exception($"Invalid location: {locationName}");
        card.StartTrip(location);
        return string.Empty;
    }
}