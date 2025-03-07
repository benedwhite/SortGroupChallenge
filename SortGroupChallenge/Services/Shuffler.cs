using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services;

public sealed class Shuffler : IShuffler
{
    public IEnumerable<Card> Shuffle(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        Random random = new();

        return cards.OrderBy(_ => random.Next());
    }
}
