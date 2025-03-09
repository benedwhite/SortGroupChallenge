using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Models;

public class DeckTests
{
    private readonly Cards _cards = new
        ([
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
            new Card(new Suit(Constants.Suit.Spades), new Rank(Constants.Rank.King))]);

    [Fact]
    public void Create_ShouldCreateADeckContainingAllCards()
    {
        // Arrange & Act
        var sut = new Deck();

        // Assert
        Assert.Equal(52, sut.Cards.Count);
        Assert.True(sut.Cards.SequenceEqual(_cards));
    }

    [Fact]
    public void Shuffle_ShouldShuffleCardsAndChangeOrder()
    {
        // Arrange & Act
        Deck sut = new Deck().Shuffle(new Shuffler());

        // Assert
        Assert.Equal(52, sut.Cards.Count);
        Assert.False(sut.Cards.SequenceEqual(_cards));
    }
}
