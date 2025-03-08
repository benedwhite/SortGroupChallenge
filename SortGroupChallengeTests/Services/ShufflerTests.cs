﻿using SortGroupChallenge;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class ShufflerTests
{
    [Fact]
    public void Shuffle_ShouldShuffleCardsAndChangeOrder()
    {
        // Arrange
        Shuffler shuffler = new();

        IEnumerable<Card> cards = [
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Ace)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Two)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Three)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Four)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Five)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Six)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Seven)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Eight)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Nine)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Ten)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Jack)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.Queen)),
            Card.Create(Suit.Create(Constants.Suit.Hearts), Rank.Create(Constants.Rank.King)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Ace)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Two)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Three)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Four)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Five)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Six)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Seven)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Eight)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Nine)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Ten)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Jack)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.Queen)),
            Card.Create(Suit.Create(Constants.Suit.Diamonds), Rank.Create(Constants.Rank.King)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Ace)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Two)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Three)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Four)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Five)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Six)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Seven)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Eight)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Nine)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Ten)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Jack)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.Queen)),
            Card.Create(Suit.Create(Constants.Suit.Clubs), Rank.Create(Constants.Rank.King)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Ace)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Two)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Three)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Four)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Five)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Six)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Seven)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Eight)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Nine)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Ten)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Jack)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.Queen)),
            Card.Create(Suit.Create(Constants.Suit.Spades), Rank.Create(Constants.Rank.King))
        ];

        // Act
        var sut = shuffler.Shuffle(cards);

        // Assert
        Assert.True(sut.Count() == 52);
        Assert.False(sut.SequenceEqual(cards));
    }
}
