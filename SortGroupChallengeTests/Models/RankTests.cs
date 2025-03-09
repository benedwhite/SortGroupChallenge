using SortGroupChallenge;
using SortGroupChallenge.Models;

namespace SortGroupChallengeTests.Models;

public class RankTests
{
    [Theory]
    [InlineData(Constants.Rank.Ace)]
    [InlineData(Constants.Rank.Two)]
    [InlineData(Constants.Rank.Three)]
    [InlineData(Constants.Rank.Four)]
    [InlineData(Constants.Rank.Five)]
    [InlineData(Constants.Rank.Six)]
    [InlineData(Constants.Rank.Seven)]
    [InlineData(Constants.Rank.Eight)]
    [InlineData(Constants.Rank.Nine)]
    [InlineData(Constants.Rank.Ten)]
    [InlineData(Constants.Rank.Jack)]
    [InlineData(Constants.Rank.Queen)]
    [InlineData(Constants.Rank.King)]
    public void Create_GivenAValidRankValue_ReturnsExpectedSuit(string rankValue)
    {
        // Arrange && Act
        var sut = new Rank(rankValue);

        // Assert
        Assert.Equal(rankValue, sut.ToString());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("abc")]
    [InlineData("123")]
    [InlineData("*$*(&&(*()")]
    public void Create_GivenAnInvalidRankValue_ThrowsApplicationException(string? rankValue)
    {
        // Arrange
        Suit sut = default!;

        // Act
        Exception exception = Record.Exception(() => sut = new Suit(rankValue!));

        // Assert
        Assert.Null(sut);

        Assert.IsType<ApplicationException>(exception);
        Assert.Equal($"{rankValue} is not a valid value for suit", exception.Message);
    }
}
