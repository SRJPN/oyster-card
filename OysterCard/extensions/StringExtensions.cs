using System.Diagnostics.CodeAnalysis;
using OysterCard.models;

namespace MyMoney.extensions
{
    [ExcludeFromCodeCoverage]
    public static class StringExtension
    {
        public static ITransportMode ToTransportMode(this string value)
        {
            if (value == "TUBE")
                return new TubeTransportMode();
            else if (value == "BUS")
                return new BusTransportMode();
            else
                throw new Exception("Invalid mode of transport");
        }
    }
}