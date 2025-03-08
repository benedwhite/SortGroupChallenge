using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandWinnerAnnouncer : IWinnerAnnouncer
{
    public event EventHandler<Player>? PlayerWon;

    private StandWinnerAnnouncer() { }

    public static StandWinnerAnnouncer Create() => new();

    public void AnnounceWinnerFrom(IEnumerable<Player> players)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));

        Player winner = players
            .OrderByDescending(p => p.HandCount())
            .First();

        PlayerWon?.Invoke(this, winner);
    }
}
