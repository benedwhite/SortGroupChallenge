using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed class Deck
{
    public Cards Cards { get; }

    private Deck(Cards cards) => Cards = cards;

    public static Deck Create()
    {
        IEnumerable<Card> cards = Suit.AllSuits
            .SelectMany(
                suit => Rank.AllRanks,
                (suit, rank) => Card.Create(
                    Suit.Create(suit),
                    Rank.Create(rank)));

        var pack = Cards.Create(cards);

        return new(pack);
    }

    public Deck Shuffle(IShuffler shuffler)
    {
        ArgumentNullException.ThrowIfNull(shuffler, nameof(shuffler));

        Cards shuffledCards = shuffler.Shuffle(Cards);

        return new(shuffledCards);
    }

    public int Count() => Cards.Count;
}
