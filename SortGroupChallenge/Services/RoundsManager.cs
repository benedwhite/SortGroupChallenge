using SortGroupChallenge.Services.Abstractions;

namespace SortGroupChallenge.Services;

public sealed class RoundsManager : IRoundsManager
{
    private readonly int _maxRounds;

    public RoundsManager(int maxRounds)
    {
        if (maxRounds <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxRounds), "Max rounds must be greater than 0.");
        }

        _maxRounds = maxRounds;
    }

    public bool IsWithinRoundLimit(int round)
    {
        if (round <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(round), "Round must be greater than 0.");
        }

        return round <= _maxRounds;
    }
}
