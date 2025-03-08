using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardGameRoundService : IGameRoundService
{
    private readonly Queue<Card> _table;
    private readonly Player _player;

    private StandardGameRoundService(Queue<Card> table, Player player)
    {
        _table = table;
        _player = player;
    }

    public static StandardGameRoundService Create(Queue<Card> table, Player player)
    {
        ArgumentNullException.ThrowIfNull(table, nameof(table));
        ArgumentNullException.ThrowIfNull(player, nameof(player));

        return new(table, player);
    }

    public bool HasGameEndedAfterTurn(ISnapService snapService)
    {
        if (_player.HasEmptyHand())
        {
            return true;
        }

        if (snapService.Snap(_player))
        {
            _player.Pickup(_table);
            _table.Clear();
        }

        return false;
    }
}
