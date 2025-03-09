using System.Collections;

namespace SortGroupChallenge.Models;

public sealed record Players(IEnumerable<Player> Player) : IEnumerable<Player>
{
    public IEnumerator<Player> GetEnumerator() => Player.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
