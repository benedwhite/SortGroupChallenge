using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class RankMatcherTests
{
    [Fact]
    public void Create_ShouldReturnRankMatcher_WhenCardIsValid()
    {
        // Arrange
        var rank = new Rank(Constants.Rank.Ace);
        var card = new Card(new Suit(Constants.Suit.Hearts), rank);

        // Act
        var rankMatcher = new RankMatcherService(card);

        // Assert
        Assert.NotNull(rankMatcher);
    }

    [Fact]
    public void Matches_ShouldThrowArgumentNullException_WhenCardIsNull()
    {
        // Arrange
        var rank = new Rank(Constants.Rank.Ace);
        var card = new Card(new Suit(Constants.Suit.Hearts), rank);
        var sut = new RankMatcherService(card);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut.Matches(null!));
    }

    [Fact]
    public void Matches_ShouldReturnTrue_WhenRanksMatch()
    {
        // Arrange
        var rank = new Rank(Constants.Rank.Ace);
        var card1 = new Card(new Suit(Constants.Suit.Hearts), rank);
        var card2 = new Card(new Suit(Constants.Suit.Diamonds), rank);
        var sut = new RankMatcherService(card1);

        // Act
        bool result = sut.Matches(card2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Matches_ShouldReturnFalse_WhenRanksDoNotMatch()
    {
        // Arrange
        var rank1 = new Rank(Constants.Rank.Ace);
        var rank2 = new Rank(Constants.Rank.King);
        var card1 = new Card(new Suit(Constants.Suit.Hearts), rank1);
        var card2 = new Card(new Suit(Constants.Suit.Diamonds), rank2);
        var sut = new RankMatcherService(card1);

        // Act
        bool result = sut.Matches(card2);

        // Assert
        Assert.False(result);
    }
}
