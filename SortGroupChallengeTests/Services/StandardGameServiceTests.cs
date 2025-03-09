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
        var table = Table.Create();

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
        var table = Table.Create();

        var cards = Cards.Create([
            Card.Create(
                Suit.Create(Constants.Suit.Spades),
                Rank.Create(Constants.Rank.Ace))]);

        player.Pickup(cards);

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Single(table.GetCards());
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysMatchingCard_ClearsTable()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");

        var cards = Cards.Create([
            Card.Create(
                Suit.Create(Constants.Suit.Spades),
                Rank.Create(Constants.Rank.Ace))]);

        player.Pickup(cards);

        var table = Table.Create();

        table.AddCard(Card.Create(
            Suit.Create(Constants.Suit.Diamonds),
            Rank.Create(Constants.Rank.Ace)));

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.Equal(2, player.HandCount());
        Assert.False(result);
        Assert.Empty(table.GetCards());
    }

    [Fact]
    public void HasGameEndedAfterTurn_PlayerPlaysNonMatchingCard_AddsToTable()
    {
        // Arrange
        var service = StandardGameRoundService.Create();
        var player = Player.Create("TestPlayer");

        var cards = Cards.Create([
            Card.Create(
                Suit.Create(Constants.Suit.Spades),
                Rank.Create(Constants.Rank.Ace))]);

        player.Pickup(cards);

        var table = Table.Create();

        table.AddCard(Card.Create(
            Suit.Create(Constants.Suit.Diamonds),
            Rank.Create(Constants.Rank.Ten)));

        // Act
        bool result = service.HasGameEndedAfterTurn(table, player);

        // Assert
        Assert.False(result);
        Assert.Equal(2, table.CardCount());
    }
}