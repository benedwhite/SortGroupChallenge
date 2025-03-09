using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public record RankMatcher(Card Card) : ICardMatcher
{
    public bool Matches(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        return Card.Rank == card.Rank;
    }
}
