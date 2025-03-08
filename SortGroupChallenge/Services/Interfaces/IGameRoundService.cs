using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IGameRoundService
{
    bool PlayerHasWon(Player player);
}
