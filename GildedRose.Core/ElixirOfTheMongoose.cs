namespace GildedRose
{
    public class ElixirOfTheMongoose : Item, IItem
    {
        public ElixirOfTheMongoose(Days shelfLife, Quality quality)
            : base("Elixir of the Mongoose", shelfLife, quality)
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
}