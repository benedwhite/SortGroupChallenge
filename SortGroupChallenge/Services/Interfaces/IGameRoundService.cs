
using SortGroupChallenge.Models;

public interface IGameRoundService
{
    bool HasGameEndedAfterTurn(Queue<Card> table, Player player);
}
