using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public class RankMatcher : ICardMatcher
{
    private readonly Rank _rank;

    private RankMatcher(Rank rank) => _rank = rank;

    public static RankMatcher Create(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        return new(card.Rank);
    }

    public bool Matches(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        return _rank == card.Rank;
    }
}
