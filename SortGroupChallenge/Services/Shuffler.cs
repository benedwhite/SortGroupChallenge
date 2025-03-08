using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class Shuffler : IShuffler
{
    public IEnumerable<Card> Shuffle(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        return cards
            .OrderBy(_ => Guid.NewGuid())
            .ToList();
    }
}
