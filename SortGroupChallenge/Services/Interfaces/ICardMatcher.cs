using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Interfaces;

public interface ICardMatcher
{
    bool Matches(Card card);
}
