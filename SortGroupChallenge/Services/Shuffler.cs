using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed record Shuffler : IShuffler
{
    public Cards Shuffle(Cards cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        var shuffledCards = cards
            .OrderBy(_ => Guid.NewGuid())
            .ToList();

        var pack = new Cards(shuffledCards);

        return pack;
    }
}
