using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Abstractions;

public interface IWinnerAnnouncerService
{
    void AnnounceWinnerFrom(Players players);
}
