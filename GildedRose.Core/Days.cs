using System;

namespace GildedRose
{
    public readonly struct Days : IComparable
    {
        private readonly int _value;

        public Days(int value)
        {
            _value = value;
        }

        public static bool operator ==(Days left, Days right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Days left, Days right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Days left, Days right)
        {
            return left._value < right._value;
        }

        public static bool operator >(Days left, Days right)
        {
            return left._value > right._value;
        }

        public static Days operator -(Days left)
        {
            return new Days(-left._value);
        }

        public bool Equals(Days other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Days && Equals((Days)obj);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public int CompareTo(object obj)
        {
            return _value.CompareTo(((Days)obj)._value);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public Days ReduceByOneDay()
        {
            return new Days(_value - 1);
        }
    }
}