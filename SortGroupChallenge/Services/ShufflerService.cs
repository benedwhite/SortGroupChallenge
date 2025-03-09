using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Services;

public sealed record ShufflerService : IShufflerService
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
