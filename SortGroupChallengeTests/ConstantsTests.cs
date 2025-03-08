using SortGroupChallenge;

namespace SortGroupChallengeTests;

public class ConstantsTests
{
    [Fact]
    public void Init_ShouldDefineConstantsCorrectly()
    {
        // Assert
        Assert.Equal(Constants.Suit.Hearts, "Hearts");
        Assert.Equal(Constants.Suit.Diamonds, "Diamonds");
        Assert.Equal(Constants.Suit.Clubs, "Clubs");
        Assert.Equal(Constants.Suit.Spades, "Spades");

        Assert.Equal(Constants.Rank.Ace, "Ace");
        Assert.Equal(Constants.Rank.Two, "Two");
        Assert.Equal(Constants.Rank.Three, "Three");
        Assert.Equal(Constants.Rank.Four, "Four");
        Assert.Equal(Constants.Rank.Five, "Five");
        Assert.Equal(Constants.Rank.Six, "Six");
        Assert.Equal(Constants.Rank.Seven, "Seven");
        Assert.Equal(Constants.Rank.Eight, "Eight");
        Assert.Equal(Constants.Rank.Nine, "Nine");
        Assert.Equal(Constants.Rank.Ten, "Ten");
        Assert.Equal(Constants.Rank.Jack, "Jack");
        Assert.Equal(Constants.Rank.Queen, "Queen");
        Assert.Equal(Constants.Rank.King, "King");

        Assert.Equal(Constants.Player.MinPlayerCount, 2);
        Assert.Equal(Constants.Player.MaxPlayerCount, 4);
    }
}
