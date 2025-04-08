namespace GildedRose;

/// <summary>
/// Represents a valuation strategy where the quality of an item increases over time.
/// </summary>
/// <remarks>
/// The quality increases linearly as a day passes. If the item is overdue for sale,
/// the quality increases at an accelerated rate.
/// </remarks>
public class LinearValuationStrategy : IValuationStrategy
{
    public (DaySpan RemainingTimeToSell, QualityLevel Quality) ValuateAfterOneDay(DaySpan remainingTime, QualityLevel quality)
    {
        remainingTime = remainingTime.ReduceByOne();

        quality = quality.Increase();

        if (remainingTime.IsOverdue)
        {
            quality = quality.Increase();
        }

        return (remainingTime, quality);
    }
}
