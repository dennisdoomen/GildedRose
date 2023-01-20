using System;

namespace GildedRose.Specs;

public class BackstagePassBuilder
{
    private static readonly Random rand = new(3456789);
    private Quality quality = new((uint)rand.Next(50));
    private Days sellIn = new(rand.Next(30));

    public BackstagePassBuilder WhichExpires(Days days)
    {
        sellIn = days;
        return this;
    }

    public BackstagePassBuilder WithQuality(Quality initialQuality)
    {
        quality = initialQuality;
        return this;
    }

    public BackstagePass Build() => new(sellIn, quality);
}
