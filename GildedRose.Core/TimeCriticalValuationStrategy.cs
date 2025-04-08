namespace GildedRose;

/// <summary>
/// Represents a valuation strategy for items with time-sensitive quality changes.
/// </summary>
/// <remarks>
/// The quality of an item managed by this strategy increases as its remaining selling time decreases,
/// with additional quality increases triggered based on specific time thresholds. If the item's selling time expires,
/// its quality drops to zero.
/// </remarks>
public class TimeCriticalValuationStrategy(DaySpan threshold1, DaySpan threshold2) : IValuationStrategy
{
    public (DaySpan RemainingTimeToSell, QualityLevel Quality) ValuateAfterOneDay(DaySpan remainingTime, QualityLevel quality)
    {
        remainingTime = remainingTime.ReduceByOne();

        if (remainingTime.IsOverdue)
        {
            quality = QualityLevel.From(0);
        }
        else
        {
            quality = quality.Increase();

            if (remainingTime < threshold1)
            {
                quality = quality.Increase();
            }

            if (remainingTime < threshold2)
            {
                quality = quality.Increase();
            }
        }

        return (remainingTime, quality);
    }
}
