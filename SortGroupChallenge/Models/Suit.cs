namespace SortGroupChallenge.Models;

public sealed record Suit
{
    private readonly string _value;
    private Suit(string value) => _value = value;

    public static Suit Create(string value)
    {
        string? suitValue = AllSuits.FirstOrDefault(s => s == value);

        return suitValue is not null ?
            new(suitValue) :
            throw new ApplicationException($"{value} is not a valid value for suit");
    }

    public override string ToString() => _value;

    public static readonly IReadOnlyCollection<string> AllSuits =
    [
        Constants.Suit.Hearts,
        Constants.Suit.Diamonds,
        Constants.Suit.Clubs,
        Constants.Suit.Spades
    ];
}