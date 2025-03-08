using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface ICardMatcher
{
    public bool Matches(Card card);
}
