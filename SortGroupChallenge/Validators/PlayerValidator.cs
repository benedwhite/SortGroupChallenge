using SortGroupChallenge.Validators.Abstractions;

namespace SortGroupChallenge.Validators;

public sealed record PlayerValidator(int NumberOfPlayersToCreate) : IGameValidator
{
    public bool IsValid() =>
        NumberOfPlayersToCreate >= Constants.Player.MinPlayerCount
        && NumberOfPlayersToCreate <= Constants.Player.MaxPlayerCount;
}
