namespace SortGroupChallenge.Models;

public sealed class Cards : Stack<Card>
{
    private Cards() { }

    public static Cards Create() => new();
}
