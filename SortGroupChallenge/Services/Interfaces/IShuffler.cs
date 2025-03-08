using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IShuffler
{
    public IEnumerable<Card> Shuffle(IEnumerable<Card> cards);
}
