using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed record Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    private Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public static Card Create(Suit suit, Rank rank)
    {
        ArgumentNullException.ThrowIfNull(suit, nameof(suit));
        ArgumentNullException.ThrowIfNull(rank, nameof(rank));

        return new(suit, rank);
    }

    public bool Matches(ICardMatcher cardMatcher)
    {
        ArgumentNullException.ThrowIfNull(cardMatcher, nameof(cardMatcher));

        return cardMatcher.Matches(this);
    }
}
