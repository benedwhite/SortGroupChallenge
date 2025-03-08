using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class GameManager
{
    private readonly IEnumerable<IGameValidator> _gameValidators;
    private readonly Game _game;

    private GameManager(IEnumerable<IGameValidator> gameValidators, Game game)
    {
        _gameValidators = gameValidators;
        _game = game;
    }

    public static GameManager Create(IEnumerable<IGameValidator> gameValidators, Game game)
    {
        ArgumentNullException.ThrowIfNull(gameValidators, nameof(gameValidators));
        ArgumentNullException.ThrowIfNull(game, nameof(game));

        return new(gameValidators, game);
    }

    public void Play()
    {
        if (!_gameValidators.Any(v => v.IsValid()))
        {
            throw new ApplicationException("Game is not valid");
        }

        _game.Start();
    }
}
