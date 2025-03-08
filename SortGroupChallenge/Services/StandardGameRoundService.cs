using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services;

public sealed class StandardGameRoundService : IGameRoundService
{
    private StandardGameRoundService() { }

    public static StandardGameRoundService Create() => new();

    public bool HasGameEndedAfterTurn(Queue<Card> table, Player player)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        if (player.HasEmptyHand())
        {
            return true;
        }

        Card? playedCard = player.PlayCard();
        Card? cardOnTable = table.LastOrDefault();

        if (playedCard is null)
        {
            return false;
        }

        table.Enqueue(playedCard);

        var snap = cardOnTable is not null ?
            playedCard.Matches(RankMatcher.Create(cardOnTable)) :
            false;

        if (snap)
        {
            player.Pickup(table);
            table.Clear();
        }

        return false;
    }
}
