using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardPlayerFactory : IPlayerFactory
{
    private readonly IGameValidator _gameValidator;

    private StandardPlayerFactory(IGameValidator gameValidator)
        => _gameValidator = gameValidator;

    public static StandardPlayerFactory Create(IGameValidator gameValidator)
    {
        ArgumentNullException.ThrowIfNull(gameValidator, nameof(gameValidator));

        return new(gameValidator);
    }

    public Players CreateMany(int numberOfPlayersToCreate)
    {
        if (!_gameValidator.IsValid())
        {
            throw new InvalidOperationException($"Number of players must be between " +
                $"{Constants.Player.MinPlayerCount} and {Constants.Player.MaxPlayerCount}.");
        }

        var playersToCreate = Enumerable
            .Range(0, numberOfPlayersToCreate)
            .Select(index => Player.Create($"Player {index + 1}"))
            .ToList();

        var players = Players.Create(playersToCreate);

        return players;
    }
}
