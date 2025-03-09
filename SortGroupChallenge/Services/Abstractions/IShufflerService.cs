using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Abstractions;

public interface IShufflerService
{
    Cards Shuffle(Cards cards);
}
