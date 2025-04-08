using System;

namespace GildedRose.Specs;

public class BackstagePassBuilder
{
    private static readonly Random rand = new(3456789);
    private QualityLevel quality = QualityLevel.From((uint)rand.Next(50));
    private int sellIn = rand.Next(30);

    public BackstagePassBuilder WhichExpiresInDays(int days)
    {
        sellIn = days;
        return this;
    }

    public BackstagePassBuilder WithQuality(QualityLevel initialQuality)
    {
        quality = initialQuality;
        return this;
    }

    public Item Build() => new("Backstage passes to a TAFKAL80ETC concert",
        new TimeCriticalValuationStrategy(DaySpan.From(10), DaySpan.From(5)), DaySpan.From(sellIn), quality);
}
