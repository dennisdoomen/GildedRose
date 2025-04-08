namespace GildedRose;

public interface IValuationStrategy
{
    (DaySpan RemainingTimeToSell, QualityLevel Quality) ValuateAfterOneDay(DaySpan remainingTime, QualityLevel quality);
}
