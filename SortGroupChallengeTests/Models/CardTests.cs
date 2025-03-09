using SortGroupChallenge;
using SortGroupChallenge.Models;

namespace SortGroupChallengeTests.Models;

public class CardTests
{
    [Theory]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Ace)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Two)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Three)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Four)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Five)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Six)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Seven)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Eight)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Nine)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Ten)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Jack)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.Queen)]
    [InlineData(Constants.Suit.Hearts, Constants.Rank.King)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Ace)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Two)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Three)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Four)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Five)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Six)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Seven)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Eight)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Nine)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Ten)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Jack)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.Queen)]
    [InlineData(Constants.Suit.Diamonds, Constants.Rank.King)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Ace)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Two)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Three)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Four)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Five)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Six)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Seven)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Eight)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Nine)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Ten)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Jack)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.Queen)]
    [InlineData(Constants.Suit.Clubs, Constants.Rank.King)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Ace)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Two)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Three)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Four)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Five)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Six)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Seven)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Eight)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Nine)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Ten)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Jack)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.Queen)]
    [InlineData(Constants.Suit.Spades, Constants.Rank.King)]
    public void Create_ShouldSetCorrectSuitAndRank(string suitValue, string rankValue)
    {
        // Arrange & Act
        var sut = new Card(
            new Suit(suitValue),
            new Rank(rankValue)
        );

        // Assert
        Assert.Equal(suitValue, sut.Suit.ToString());
        Assert.Equal(rankValue, sut.Rank.ToString());
    }
}
