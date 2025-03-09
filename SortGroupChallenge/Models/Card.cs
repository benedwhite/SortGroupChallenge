using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed record Card(Suit Suit, Rank Rank)
{
    public bool Matches(ICardMatcher cardMatcher)
    {
        ArgumentNullException.ThrowIfNull(cardMatcher, nameof(cardMatcher));

        return cardMatcher.Matches(this);
    }
}
