using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardWinnerAnnouncer : IWinnerAnnouncer
{
    public event EventHandler<Player?>? PlayerWon;

    private StandardWinnerAnnouncer() { }

    public static StandardWinnerAnnouncer Create() => new();

    public void AnnounceWinnerFrom(IEnumerable<Player> players)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));

        IGrouping<int, Player>? playersGroupedByScore = players
            .GroupBy(p => p.HandCount())
            .OrderByDescending(g => g.Key)
            .FirstOrDefault();

        bool isDraw = playersGroupedByScore is not null && playersGroupedByScore.Count() > 1;

        if (isDraw)
        {
            RaiseEvent(null);

            return;
        }

        Player? winner = playersGroupedByScore?.Single();

        RaiseEvent(winner);
    }

    private void RaiseEvent(Player? winner)
    {
        PlayerWon?.Invoke(this, winner);
    }
}
