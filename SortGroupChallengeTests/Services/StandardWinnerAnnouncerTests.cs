using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class StandardWinnerAnnouncerTests
{
    [Fact]
    public void AnnounceWinnerFrom_ShouldRaiseEventWithWinner_WhenThereIsASingleWinner()
    {
        // Arrange
        var players = Players.Create([
            Player.Create("Player1"),
            Player.Create("Player2")]);

        players
            .First()
            .Pickup(
                Cards.Create(
                    [Card.Create(
                        Suit.Create(Constants.Suit.Spades),
                        Rank.Create(Constants.Rank.Ace))]));

        players
            .Last()
            .Pickup(Cards.Create([]));

        var announcer = StandardWinnerAnnouncer.Create();

        Player? announcedWinner = null;

        announcer.PlayerWon += (_, winner) => announcedWinner = winner;

        // Act
        announcer.AnnounceWinnerFrom(players);

        // Assert
        Assert.NotNull(announcedWinner);
        Assert.Equal("Player1", announcedWinner?.ToString());
    }

    [Fact]
    public void AnnounceWinnerFrom_ShouldRaiseEventWithNull_WhenThereIsADraw()
    {
        // Arrange
        var players = Players.Create([
            Player.Create("Player1"),
            Player.Create("Player2")]);

        players
            .First()
            .Pickup(
                Cards.Create(
                    [Card.Create(
                        Suit.Create(Constants.Suit.Spades),
                        Rank.Create(Constants.Rank.Ace))]));

        players
            .Last()
            .Pickup(
                Cards.Create(
                    [Card.Create(
                        Suit.Create(Constants.Suit.Hearts),
                        Rank.Create(Constants.Rank.Ten))]));

        var announcer = StandardWinnerAnnouncer.Create();

        Player? announcedWinner = null;

        announcer.PlayerWon += (_, winner) => announcedWinner = winner;

        // Act
        announcer.AnnounceWinnerFrom(players);

        // Assert
        Assert.Null(announcedWinner);
    }

    [Fact]
    public void AnnounceWinnerFrom_ShouldThrowArgumentNullException_WhenPlayersIsNull()
    {
        // Arrange
        var announcer = StandardWinnerAnnouncer.Create();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => announcer.AnnounceWinnerFrom(null!));
    }
}
