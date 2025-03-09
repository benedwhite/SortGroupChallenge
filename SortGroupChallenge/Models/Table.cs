namespace SortGroupChallenge.Models;

public sealed record Table
{
    private readonly Stack<Card> _cards = [];

    private Table() { }

    public static Table Create() => new();

    public void AddCard(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        _cards.Push(card);
    }

    public Card? TryPickupCard() => _cards.TryPeek(out Card? card) ? card : null;

    public void ClearCards() => _cards.Clear();

    public Stack<Card> GetCards() => _cards;

    public int CardCount() => _cards.Count;
}
