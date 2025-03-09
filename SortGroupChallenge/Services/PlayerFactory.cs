using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed record PlayerFactory(IGameValidator GameValidator) : IPlayerFactory
{
    public Players CreateMany(int numberOfPlayersToCreate)
    {
        if (!GameValidator.IsValid())
        {
            throw new InvalidOperationException($"Number of players must be between " +
                $"{Constants.Player.MinPlayerCount} and {Constants.Player.MaxPlayerCount}.");
        }

        var playersToCreate = Enumerable
            .Range(0, numberOfPlayersToCreate)
            .Select(index => new Player($"Player {index + 1}"))
            .ToList();
        
        var players = new Players(playersToCreate);

        return players;
    }
}
