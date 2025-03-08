using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardSnapService : ISnapService
{
    private readonly Queue<Card> _table;

    private StandardSnapService(Queue<Card> table) => _table = table;

    public static StandardSnapService Create(Queue<Card> table)
    {
        ArgumentNullException.ThrowIfNull(table, nameof(table));

        return new(table);
    }

    public bool Snap(Player player)
    {
        Card? playedCard = player.PlayCard();
        Card? cardOnTable = _table.LastOrDefault();

        if (playedCard is null)
        {
            return false;
        }

        _table.Enqueue(playedCard);

        return cardOnTable is not null ?
            playedCard.Matches(RankMatcher.Create(cardOnTable)) :
            false;
    }
}
