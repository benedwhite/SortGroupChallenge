using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Services;

public sealed record WinnerAnnouncerService : IWinnerAnnouncerService
{
    public event EventHandler<Player?>? PlayerWon;

    public void AnnounceWinnerFrom(Players players)
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

    private void RaiseEvent(Player? winner) => PlayerWon?.Invoke(this, winner);
}
