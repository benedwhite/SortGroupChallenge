using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services;

public interface IShuffler
{
    public IEnumerable<Card> Shuffle(IEnumerable<Card> cards);
}
