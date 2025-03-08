using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardGameRoundService : IGameRoundService
{
    private readonly Queue<Card> _table;

    private StandardGameRoundService(Queue<Card> table) => _table = table;

    public static StandardGameRoundService Create(Queue<Card> table)
    {
        ArgumentNullException.ThrowIfNull(table, nameof(table));

        return new(table);
    }

    public bool PlayerHasWon(Player player)
    {
        Card playedCard = player.PlayCard();
        Card? cardOnTable = _table.LastOrDefault();

        if (cardOnTable is null)
        {
            _table.Enqueue(playedCard);

            return false;
        }

        bool snap = playedCard.Matches(RankMatcher.Create(cardOnTable));

        if (snap)
        {
            _table.Clear();

            return true;
        }

        _table.Enqueue(playedCard);

        return false;
    }
}
