using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class WinnerAnnouncerTests
{
    [Fact]
    public void AnnounceWinnerFrom_ShouldRaiseEventWithWinner_WhenThereIsASingleWinner()
    {
        // Arrange
        var players = new Players([
            new Player("Player1"),
            new Player("Player2")]);

        players
            .First()
            .Pickup(
                new Cards(
                    [new Card(
                        new Suit(Constants.Suit.Spades),
                        new Rank(Constants.Rank.Ace))]));

        players
            .Last()
            .Pickup(new Cards([]));

        var sut = new WinnerAnnouncer();

        Player? announcedWinner = null;

        sut.PlayerWon += (_, winner) => announcedWinner = winner;

        // Act
        sut.AnnounceWinnerFrom(players);

        // Assert
        Assert.NotNull(announcedWinner);
        Assert.Equal("Player1", announcedWinner?.ToString());
    }

    [Fact]
    public void AnnounceWinnerFrom_ShouldRaiseEventWithNull_WhenThereIsADraw()
    {
        // Arrange
        var players = new Players([
            new Player("Player1"),
            new Player("Player2")]);

        players
            .First()
            .Pickup(
                new Cards(
                    [new Card(
                        new Suit(Constants.Suit.Spades),
                        new Rank(Constants.Rank.Ace))]));

        players
            .Last()
            .Pickup(
                new Cards(
                    [new Card(
                        new Suit(Constants.Suit.Hearts),
                        new Rank(Constants.Rank.Ten))]));

        var sut = new WinnerAnnouncer();

        Player? announcedWinner = null;

        sut.PlayerWon += (_, winner) => announcedWinner = winner;

        // Act
        sut.AnnounceWinnerFrom(players);

        // Assert
        Assert.Null(announcedWinner);
    }

    [Fact]
    public void AnnounceWinnerFrom_ShouldThrowArgumentNullException_WhenPlayersIsNull()
    {
        // Arrange
        var announcer = new WinnerAnnouncer();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => announcer.AnnounceWinnerFrom(null!));
    }
}
