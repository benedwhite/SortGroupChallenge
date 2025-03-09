using System.Collections;

namespace SortGroupChallenge.Models;

public sealed record Players : IEnumerable<Player>
{
    private readonly IEnumerable<Player> _players;

    private Players(IEnumerable<Player> players)
    {
        _players = [.. players];
    }

    public static Players Create(IEnumerable<Player> players)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));

        return new(players);
    }

    public IEnumerator<Player> GetEnumerator() => _players.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
