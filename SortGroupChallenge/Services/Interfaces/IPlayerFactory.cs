using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IPlayerFactory
{
    Players CreateMany(int numberOfPlayersToCreate);
}