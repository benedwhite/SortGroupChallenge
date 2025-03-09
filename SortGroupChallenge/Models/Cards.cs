namespace SortGroupChallenge.Models;

public sealed class Cards(IEnumerable<Card> cards) : Stack<Card>(cards) { }
