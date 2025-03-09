using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Services;

public record RankMatcherService(Card Card) : ICardMatcherService
{
    public bool Matches(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        return Card.Rank == card.Rank;
    }
}
