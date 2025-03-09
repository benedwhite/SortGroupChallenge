namespace SortGroupChallenge.Models;

public sealed record Rank
{
    private readonly string _value;

    public Rank(string value)
    {
        if (!AllRanks.Contains(value))
        {
            throw new ApplicationException($"{value} is not a valid value for rank");
        }

        _value = value;
    }

    public override string ToString() => _value;

    public static readonly IReadOnlyCollection<string> AllRanks = new HashSet<string>
    {
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
    };
}
