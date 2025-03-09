using System.Collections.ObjectModel;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed record Deck(Cards Cards)
{
    public Deck() : this(new Cards(GenerateAllCards())) { }

    public int Count => Cards.Count;

    public Deck Shuffle(IShuffler shuffler)
    {
        ArgumentNullException.ThrowIfNull(shuffler, nameof(shuffler));

        Cards shuffledCards = shuffler.Shuffle(Cards);

        return new(shuffledCards);
    }

    private static IReadOnlyList<Card> GenerateAllCards() =>
        [.. Suit.AllSuits.SelectMany(
            suit => Rank.AllRanks,
            (suit, rank) => new Card(new Suit(suit), new Rank(rank)))];
}
