using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IShuffler
{
    Cards Shuffle(Cards cards);
}
