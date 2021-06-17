using System;

namespace GildedRose.Specs
{
    public class SulfurasBuilder
    {
        private static readonly Random rand = new(3456789);
        private Days sellIn = new(rand.Next(30));

        public SulfurasBuilder WithShelfLife(Days days)
        {
            sellIn = days;
            return this;
        }
        
        public Sulfuras Build()
        {
            return new(sellIn);
        }
    }
}