using SortGroupChallenge.Models;

namespace SortGroupChallenge.Factories.Abstractions;

public interface IPlayerFactory
{
    Players CreateMany(int numberOfPlayersToCreate);
}
