namespace SortGroupChallenge.Models;

public sealed class Player
{
    private readonly string _name;
    private readonly Cards _hand;

    public Player(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        _name = name;
        _hand = new Cards([]);
    }

    public override string ToString() => _name;

    public void Pickup(Cards cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        foreach (Card card in cards)
        {
            _hand.Push(card);
        }
    }

    public Card PlayCard() => _hand.Pop();

    public int HandCount() => _hand.Count;

    public bool HasCards() => HandCount() > 0;

    public bool HasEmptyHand() => HandCount() == 0;
}
