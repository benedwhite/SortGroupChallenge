using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IGameRoundService
{
    bool HasGameEndedAfterTurn(Queue<Card> table, Player player);
}
