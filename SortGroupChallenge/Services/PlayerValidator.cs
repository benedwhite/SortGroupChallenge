using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class PlayerValidator : IGameValidator
{
    private const uint MinPlayerCount = 2;
    private const uint MaxPlayerCount = 4;

    private readonly IEnumerable<Player> _players;

    private PlayerValidator (IEnumerable<Player> players) => _players = players;

    public static PlayerValidator Create(IEnumerable<Player> players)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));

        return new(players);
    }

    public bool IsValid()
    {
        int playerCount = _players.Count();

        if (playerCount < MinPlayerCount || playerCount > MaxPlayerCount)
        {
            return false;
        }

        return true;
    }
}
