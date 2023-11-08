using OysterCard.models;

namespace OysterCard.handlers;

public class BalanceCommandHandler : ICommandHandler
{
    public string Execute(Card card, params string[] args)
    {
        return card.GetBalance().ToString("0.00");
    }
}