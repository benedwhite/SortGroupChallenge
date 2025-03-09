using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class GameRoundServiceTests
{
    [Fact]
    public void HasGameEndedAfterTurn_PlayerHasEmptyHand_ReturnsTrue()
    {
        // Arrange
        var sut = new GameRoundService();
        var player = new Player("TestPlayer");
        var table = new Table();

        // Act
        bool result = sut.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysCard_ReturnsFalse()
    {
        // Arrange
        var sut = new GameRoundService();
        var player = new Player("TestPlayer");
        var table = new Table();

        var cards = new Cards([
            new Card(
                new Suit(Constants.Suit.Spades),
                new Rank(Constants.Rank.Ace))]);

        player.Pickup(cards);

        // Act
        bool result = sut.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Single(table.GetCards());
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysMatchingCard_ClearsTable()
    {
        // Arrange
        var sut = new GameRoundService();
        var player = new Player("TestPlayer");

        var cards = new Cards([
            new Card(
                new Suit(Constants.Suit.Spades),
                new Rank(Constants.Rank.Ace))]);

        player.Pickup(cards);

        var table = new Table();

        table.AddCard(new Card(
            new Suit(Constants.Suit.Diamonds),
            new Rank(Constants.Rank.Ace)));

        // Act
        bool result = sut.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.Equal(2, player.HandCount());
        Assert.False(result);
        Assert.Empty(table.GetCards());
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysNonMatchingCard_AddsToTable()
    {
        // Arrange
        var sut = new GameRoundService();
        var player = new Player("TestPlayer");

        var cards = new Cards([
            new Card(
                new Suit(Constants.Suit.Spades),
                new Rank(Constants.Rank.Ace))]);

        player.Pickup(cards);

        var table = new Table();

        table.AddCard(new Card(
            new Suit(Constants.Suit.Diamonds),
            new Rank(Constants.Rank.Ten)));

        // Act
        bool result = sut.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Equal(2, table.CardCount());
    }
}
