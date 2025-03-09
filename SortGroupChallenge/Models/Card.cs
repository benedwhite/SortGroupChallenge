using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Models;

public sealed record Card(Suit Suit, Rank Rank)
{
    public bool Matches(ICardMatcherService cardMatcher)
    {
        ArgumentNullException.ThrowIfNull(cardMatcher, nameof(cardMatcher));

        return cardMatcher.Matches(this);
    }
}
