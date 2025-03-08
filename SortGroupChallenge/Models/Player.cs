namespace SortGroupChallenge.Models;

public sealed record Player
{
    private string Name { get; } = string.Empty;

    private Stack<Card> _hand = new();

    private Player(string name) => Name = name;

    public static Player Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return new(name);
    }

    public override string ToString() => Name;

    public void DealHand(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        foreach (Card card in cards)
        {
            _hand.Push(card);
        }
    }

    public Card PlayCard() => _hand.Pop();

    public bool HasCards() => _hand.Count > 0;
}
