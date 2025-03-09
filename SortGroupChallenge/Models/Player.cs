namespace SortGroupChallenge.Models;

public sealed record Player
{
    private readonly string _name;

    private readonly Cards _hand;

    private Player(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Player name cannot be null or empty", nameof(name));
        }

        _name = name;
        _hand = Cards.Create([]);
    }

    public static Player Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return new(name);
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
