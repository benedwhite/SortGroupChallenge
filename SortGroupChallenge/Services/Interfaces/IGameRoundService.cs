using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IGameRoundService
{
    bool HasGameEndedAfterTurn(Table table, Player player);
}
