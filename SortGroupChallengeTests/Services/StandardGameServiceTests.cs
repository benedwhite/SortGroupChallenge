using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class StandardGameRoundServiceTests
{
    [Fact]
    public void HasGameEndedAfterTurn_PlayerHasEmptyHand_ReturnsTrue()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");
        var table = new Queue<Card>();

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysCard_ReturnsFalse()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");
        var table = new Queue<Card>();

        player.Pickup([
            Card.Create(
                Suit.Create(Constants.Suit.Spades), 
                Rank.Create(Constants.Rank.Ace))]);

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Single(table);
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysMatchingCard_ClearsTable()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");

        player.Pickup([
            Card.Create(
                Suit.Create(Constants.Suit.Spades),
                Rank.Create(Constants.Rank.Ace))]);

        var table = new Queue<Card>();

        table.Enqueue(Card.Create(
            Suit.Create(Constants.Suit.Diamonds),
            Rank.Create(Constants.Rank.Ace)));

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.Equal(2, player.HandCount());
        Assert.False(result);
        Assert.Empty(table);
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysNonMatchingCard_AddsToTable()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");

        player.Pickup([
            Card.Create(
                Suit.Create(Constants.Suit.Spades),
                Rank.Create(Constants.Rank.Ace))]);

        var table = new Queue<Card>();

        table.Enqueue(Card.Create(
            Suit.Create(Constants.Suit.Diamonds),
            Rank.Create(Constants.Rank.Ten)));

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Equal(2, table.Count);
    }
}