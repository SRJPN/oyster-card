using OysterCard.models;

namespace OysterCard.handlers;

public interface ICommandHandler
{
    string Execute(Card card, params string[] args);
}