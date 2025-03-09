using SortGroupChallenge.Models;

namespace SortGroupChallenge.Services.Abstractions;

public interface ICardMatcherService
{
    bool Matches(Card card);
}
