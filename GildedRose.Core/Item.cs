using System;
using System.Collections.Generic;

namespace GildedRose
{
    public abstract class Item : IItem
    {
        private readonly string _name;
        private Days _shelfLife;
        private Quality _quality;

        protected Item(string name, Days shelfLife, Quality quality)
        {
            _name = name;
            _quality = quality;
            _shelfLife = shelfLife;
        }

        public Days ShelfLife => _shelfLife;

        public Quality Quality => _quality;

        public bool IsExpired => _shelfLife < new Days(0);

        public Days DaysOverdue => (_shelfLife > new Days(0)) ? new Days(0) : -_shelfLife;

        public static IComparer<IItem> ByQualityComparer => new QualityComparer();

        public abstract void OnDayHasPassed();

        public override string ToString()
        {
            return $"{_name} (quality {_quality}, sell in {_shelfLife} days)";
        }

        protected bool Equals(Item other)
        {
            return _shelfLife.Equals(other._shelfLife) && string.Equals(_name, other._name) && _quality.Equals(other._quality);
        }

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
                int hashCode = _shelfLife.GetHashCode();
                hashCode = (hashCode * 397) ^ _name.GetHashCode();
                hashCode = (hashCode * 397) ^ _quality.GetHashCode();
                return hashCode;
            }
        }

        protected void IncreaseQuality()
        {
            _quality = _quality.Increase();
        }

        protected void DecreaseQuality()
        {
            _quality = _quality.Decrease();
        }

        protected void Devaluate()
        {
            _quality = new Quality(0);
        }

        protected void ReduceShelfLife()
        {
            _shelfLife = _shelfLife.ReduceByOneDay();
        }

        protected bool IsDueWithin(Days days)
        {
            return _shelfLife < days;
        }

        private class QualityComparer : IComparer<IItem>
        {
            public int Compare(IItem x, IItem y)
            {
                return x.Quality.CompareTo(y.Quality);
            }
        }
    }
}