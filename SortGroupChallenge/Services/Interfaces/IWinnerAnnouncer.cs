using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface IWinnerAnnouncer
{
    void AnnounceWinnerFrom(Players players);
}
