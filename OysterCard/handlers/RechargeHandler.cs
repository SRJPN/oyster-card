using OysterCard.models;

namespace OysterCard.handlers
{
    public class RechargeHandler : ICommandHandler
    {
        public string Execute(Card card, params string[] args)
        {
            var amount = decimal.Parse(args[0]);
            card.Recharge(amount);
            return string.Empty;
        }
    }
}