namespace GildedRose;

public class ConjuredManaCake : Item, IItem
{
    public ConjuredManaCake(Days shelfLife, Quality quality)
        : base("Conjured Mana Cake", shelfLife, quality)
    {
    }

    public override void OnDayHasPassed()
    {
        ReduceShelfLife();

        if (IsExpired)
        {
            DecreaseQuality();
        }

        DecreaseQuality();
    }
}
