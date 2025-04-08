using System;

namespace GildedRose.Specs;

public class SulfurasBuilder
{
    private static readonly Random rand = new(3456789);
    private int sellIn = rand.Next(30);

    public SulfurasBuilder WithShelfLifeInDays(int days)
    {
        sellIn = days;
        return this;
    }

    public Item Build() => new(
        "Sulfuras, Hand of Ragnaros",
        new LegendaryValuationStrategy(),
        DaySpan.From(sellIn),
        QualityLevel.From(80));
}
