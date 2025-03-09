using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed record PlayerValidator(int NumberOfPlayersToCreate) : IGameValidator
{
    public bool IsValid() =>
        NumberOfPlayersToCreate >= Constants.Player.MinPlayerCount
        && NumberOfPlayersToCreate <= Constants.Player.MaxPlayerCount;
}
