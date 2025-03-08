using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IPlayerFactory
{
    IEnumerable<Player> CreateMany(int numberOfPlayersToCreate);
}