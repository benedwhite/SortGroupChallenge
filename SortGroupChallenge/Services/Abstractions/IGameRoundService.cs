using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Abstractions;

public interface IGameRoundService
{
    bool HasGameEndedAfterTurn(Table table, Player player);
}
