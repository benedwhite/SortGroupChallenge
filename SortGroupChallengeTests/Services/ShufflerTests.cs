using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class ShufflerTests
{
    [Fact]
    public void Shuffle_ShouldShuffleCardsAndChangeOrder()
    {
        // Arrange
        var shuffler = new ShufflerService();

        var cards = new Cards([
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Ace)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Two)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Three)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Four)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Five)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Six)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Seven)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Eight)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Nine)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Ten)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Jack)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.Queen)),
            new Card(new Suit(Constants.Suit.Hearts), new Rank(Constants.Rank.King)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Ace)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Two)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Three)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Four)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Five)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Six)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Seven)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Eight)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Nine)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Ten)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Jack)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.Queen)),
            new Card(new Suit(Constants.Suit.Diamonds), new Rank(Constants.Rank.King)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Ace)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Two)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Three)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Four)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Five)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Six)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Seven)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Eight)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Nine)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Ten)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Jack)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.Queen)),
            new Card(new Suit(Constants.Suit.Clubs), new Rank(Constants.Rank.King)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Ace)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Two)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Three)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Four)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Five)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Six)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Seven)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Eight)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Nine)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Ten)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Jack)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.Queen)),
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.King))
        ]);

        // Act
        Cards sut = shuffler.Shuffle(cards);

        // Assert
        Assert.Equal(52, sut.Count);
        Assert.False(sut.SequenceEqual(cards));
    }
}
