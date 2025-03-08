using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IWinnerAnnouncer
{
    public void AnnounceWinnerFrom(IEnumerable<Player> players);
}
