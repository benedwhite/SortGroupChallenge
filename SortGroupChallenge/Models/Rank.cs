namespace SortGroupChallenge.Models;

public sealed record Rank
{
    private readonly string _value;

    private Rank(string value) => _value = value;

    public static Rank Create(string value)
    {
        string? rankValue = AllRanks.FirstOrDefault(r => r == value);

        return rankValue is not null ?
            new(rankValue) :
            throw new ApplicationException($"{value} is not a valid value for rank");
    }

    public override string ToString() => _value;

    public static readonly IReadOnlyCollection<string> AllRanks =
    [
        Constants.Rank.Ace,
        Constants.Rank.Two,
        Constants.Rank.Three,
        Constants.Rank.Four,
        Constants.Rank.Five,
        Constants.Rank.Six,
        Constants.Rank.Seven,
        Constants.Rank.Eight,
        Constants.Rank.Nine,
        Constants.Rank.Ten,
        Constants.Rank.Jack,
        Constants.Rank.Queen,
        Constants.Rank.King
    ];
}
