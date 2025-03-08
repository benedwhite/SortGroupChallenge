using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class RankMatcherTests
{
    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenCardIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => RankMatcher.Create(null!));
    }

    [Fact]
    public void Create_ShouldReturnRankMatcher_WhenCardIsValid()
    {
        // Arrange
        var rank = Rank.Create(Constants.Rank.Ace);
        var card = Card.Create(Suit.Create(Constants.Suit.Hearts), rank);

        // Act
        var rankMatcher = RankMatcher.Create(card);

        // Assert
        Assert.NotNull(rankMatcher);
    }

    [Fact]
    public void Matches_ShouldThrowArgumentNullException_WhenCardIsNull()
    {
        // Arrange
        var rank = Rank.Create(Constants.Rank.Ace);
        var card = Card.Create(Suit.Create(Constants.Suit.Hearts), rank);
        var rankMatcher = RankMatcher.Create(card);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => rankMatcher.Matches(null!));
    }

    [Fact]
    public void Matches_ShouldReturnTrue_WhenRanksMatch()
    {
        // Arrange
        var rank = Rank.Create(Constants.Rank.Ace);
        var card1 = Card.Create(Suit.Create(Constants.Suit.Hearts), rank);
        var card2 = Card.Create(Suit.Create(Constants.Suit.Diamonds), rank);
        var rankMatcher = RankMatcher.Create(card1);

        // Act
        var result = rankMatcher.Matches(card2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Matches_ShouldReturnFalse_WhenRanksDoNotMatch()
    {
        // Arrange
        var rank1 = Rank.Create(Constants.Rank.Ace);
        var rank2 = Rank.Create(Constants.Rank.King);
        var card1 = Card.Create(Suit.Create(Constants.Suit.Hearts), rank1);
        var card2 = Card.Create(Suit.Create(Constants.Suit.Diamonds), rank2);
        var rankMatcher = RankMatcher.Create(card1);

        // Act
        var result = rankMatcher.Matches(card2);

        // Assert
        Assert.False(result);
    }
}