namespace GildedRose;

public class AgedBrie : Item, IItem
{
    public AgedBrie(Days shelfLife, Quality quality)
        : base("Aged Brie", shelfLife, quality)
    {
    }

    public override void OnDayHasPassed()
    {
        ReduceShelfLife();
        if (IsExpired) IncreaseQuality();

        IncreaseQuality();
    }
}
