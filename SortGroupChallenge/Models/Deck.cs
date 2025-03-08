using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed class Deck
{
    public IEnumerable<Card> Cards { get; }

    private Deck(IEnumerable<Card> cards) => Cards = cards;

    public static Deck Create()
    {
        IEnumerable<Card> cards = Suit.AllSuits
            .SelectMany(
                suit => Rank.AllRanks,
                (suit, rank) => Card.Create(
                    Suit.Create(suit),
                    Rank.Create(rank)));

        return new(cards);
    }

    public Deck Shuffle(IShuffler shuffler)
    {
        IEnumerable<Card> shuffledCards = shuffler.Shuffle(Cards);

        return new(shuffledCards);
    }
}
