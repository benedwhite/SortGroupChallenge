namespace SortGroupChallenge.Models;

public sealed record Suit
{
    private readonly string _value;

    public Suit(string value)
    {
        if (!AllSuits.Contains(value))
        {
            throw new ApplicationException($"{value} is not a valid value for suit");
        }

        _value = value;
    }

    public override string ToString() => _value;

    public static readonly IReadOnlyCollection<string> AllSuits = new HashSet<string>
    {
        Constants.Suit.Hearts,
        Constants.Suit.Diamonds,
        Constants.Suit.Clubs,
        Constants.Suit.Spades
    };
}
