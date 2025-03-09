using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IShuffler
{
    IEnumerable<Card> Shuffle(IEnumerable<Card> cards);
}
