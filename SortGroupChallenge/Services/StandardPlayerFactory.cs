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

    public IEnumerable<Player> CreateMany(int numberOfPlayersToCreate)
    {
        if (!_gameValidator.IsValid())
        {
            throw new InvalidOperationException($"Player count must be between " +
                $"{Constants.Player.MinPlayerCount} & {Constants.Player.MaxPlayerCount}.");
        }

        foreach (var i in Enumerable.Range(0, numberOfPlayersToCreate))
        {
            yield return Player.Create($"Player {i + 1}");
        }
    }
}
