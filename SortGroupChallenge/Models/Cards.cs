namespace SortGroupChallenge.Models;

public sealed class Cards : Stack<Card>
{
    private Cards(IEnumerable<Card> cards) : base(cards) { }

    public static Cards Create(IEnumerable<Card> cards) => new(cards);
}
