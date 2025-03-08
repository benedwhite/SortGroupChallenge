using SortGroupChallenge.Models;

namespace SortGroupChallengeTests.Models;

public class GameTests
{
    [Fact]
    public void Deal_()
    {
        // Arrange
        IEnumerable<Player> players = [
            Player.Create("Player 1"),
            Player.Create("Player 2")
        ];

        Game sut = Game.Create(players, Deck.Create());

        // Act
    }
}
