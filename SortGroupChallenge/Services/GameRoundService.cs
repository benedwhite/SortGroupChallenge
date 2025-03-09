using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Services;

public sealed record GameRoundService : IGameRoundService
{
    public bool HasGameEndedAfterTurn(Table table, Player player)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        if (player.HasEmptyHand())
        {
            return true;
        }

        Card playedCard = player.PlayCard();
        Card? topCardOnTable = table.TryPickupCard();

        table.AddCard(playedCard);

        HandleSnap(table, player, playedCard, topCardOnTable);

        return false;
    }

    private static void HandleSnap(
        Table table, 
        Player player, 
        Card playedCard, 
        Card? topCardOnTable)
    {
        bool snap = topCardOnTable is not null
            && playedCard.Matches(new RankMatcherService(topCardOnTable));

        if (!snap)
        {
            return;
        }

        player.Pickup(table.GetCards());
        table.ClearCards();
    }
}
