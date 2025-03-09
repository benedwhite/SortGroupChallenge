namespace SortGroupChallenge.Services.Abstractions;

public interface IRoundsManager
{
    bool IsWithinRoundLimit(int round);
}
