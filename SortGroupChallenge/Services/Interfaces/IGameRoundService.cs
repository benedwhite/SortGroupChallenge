namespace SortGroupChallenge.Services.Interfaces;

public interface IGameRoundService
{
    public bool HasGameEndedAfterTurn(ISnapService snapService);
}
