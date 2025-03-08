using SortGroupChallenge.Models;
using SortGroupChallenge.Services;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallengeTests.Services;

public class GameManagerTests
{
    [Fact]
    public void Test_()
    {
        // Arrange
        IEnumerable<Player> players = [
            Player.Create("Player 1"),
            Player.Create("Player 2")
        ];

        var playerValidator = PlayerValidator.Create(players);

        IEnumerable<IGameValidator> gameValidators = [
            playerValidator
        ];

        var deck = Deck.Create();

        var game = Game.Create(players, deck);

        var sut = GameManager.Create(
            gameValidators,
            game);

        // Act
        sut.Play();

        int t = 0;
    }
}
