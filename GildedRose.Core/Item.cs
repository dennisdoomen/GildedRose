using System;
using System.Collections.Generic;

namespace GildedRose;

public class Item
{
    private readonly string name;
    private QualityLevel quality;
    private readonly IValuationStrategy strategy;
    private DaySpan remainingTimeToSell;

    public Item(string name, IValuationStrategy strategy, DaySpan remainingTimeToSell, QualityLevel quality)
    {
        this.name = name;
        this.quality = quality;
        this.strategy = strategy;
        this.remainingTimeToSell = remainingTimeToSell;
    }

    public static IComparer<Item> ByQualityComparer => new QualityComparer();

    public bool IsOverdue => remainingTimeToSell.IsOverdue;

    public QualityLevel Quality => quality;

    public int DaysOverdue => remainingTimeToSell.DaysOverdue;

    public void OnDayHasPassed()
    {
        (remainingTimeToSell, quality) = strategy.ValuateAfterOneDay(remainingTimeToSell, quality);
    }

    public override string ToString() => $"{name} (quality {quality}, sell in {remainingTimeToSell} days)";

    #region Equality Members

    private bool Equals(Item other) =>
        remainingTimeToSell.Equals(other.remainingTimeToSell) && string.Equals(name, other.name, StringComparison.Ordinal) &&
        quality.Equals(other.quality);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = remainingTimeToSell.GetHashCode();
            hashCode = hashCode * 397 ^ name.GetHashCode(StringComparison.Ordinal);
            hashCode = hashCode * 397 ^ quality.GetHashCode();
            return hashCode;
        }
    }

    #endregion

    private class QualityComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y) => x.quality.CompareTo(y.quality);
    }
}
