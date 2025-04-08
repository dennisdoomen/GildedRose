namespace GildedRose;

/// <summary>
/// Represents a strategy for the linear devaluation of an item's quality over time.
/// </summary>
/// <remarks>
/// The quality decreases by a fixed amount when a day passes.
/// If the remaining time to sell has elapsed, the quality decreases further.
/// </remarks>
public class LinearDevaluationStrategy : IValuationStrategy
{
    public (DaySpan RemainingTimeToSell, QualityLevel Quality) ValuateAfterOneDay(DaySpan remainingTime, QualityLevel quality)
    {
        remainingTime = remainingTime.ReduceByOne();

        quality = quality.Decrease();

        if (remainingTime.IsOverdue)
        {
            quality = quality.Decrease();
        }

        return (remainingTime, quality);
    }
}
