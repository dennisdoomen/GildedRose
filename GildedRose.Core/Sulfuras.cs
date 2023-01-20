namespace GildedRose;

public class Sulfuras : Item, IItem
{
    public Sulfuras(Days shelfLife)
        : base("Sulfuras, Hand of Ragnaros", shelfLife, new Quality(80))
    {
    }

    public override void OnDayHasPassed()
    {
    }
}
