using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IWinnerAnnouncer
{
    void AnnounceWinnerFrom(IEnumerable<Player> players);
}
