using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class PlayerValidator : IGameValidator
{
    private readonly int _numberOfPlayersToCreate;

    private PlayerValidator(int numberOfPlayersToCreate)
        => _numberOfPlayersToCreate = numberOfPlayersToCreate;

    public static PlayerValidator Create(int numberOfPlayersToCreate) => new(numberOfPlayersToCreate);

    public bool IsValid() => _numberOfPlayersToCreate >= Constants.Player.MinPlayerCount 
        && _numberOfPlayersToCreate <= Constants.Player.MaxPlayerCount;
}
