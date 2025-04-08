namespace GildedRose;

/// <summary>
/// Represents a valuation strategy for legendary items in the inventory.
/// </summary>
/// <remarks>
/// This strategy ensures that the quality and remaining time to sell of legendary items remain unchanged.
/// </remarks>
public class LegendaryValuationStrategy : IValuationStrategy
{
    public (DaySpan RemainingTimeToSell, QualityLevel Quality) ValuateAfterOneDay(DaySpan remainingTime, QualityLevel quality)
    {
        // Legendary items do not change in quality or shelf life
        return (remainingTime, quality);
    }
}
