using System.Diagnostics.CodeAnalysis;
using OysterCard.models;

namespace MyMoney.extensions
{
    [ExcludeFromCodeCoverage]
    public static class StringExtension
    {
        public static TransportMode ToTransportMode(this string value)
        {
            return Enum.TryParse(value, true, out TransportMode result) ? result : throw new Exception("Invalid Transportion mode");
        }
    }
}