using System;

namespace GildedRose;

public readonly struct Quality : IComparable
{
    private readonly uint _value;

    public Quality(uint value)
    {
        _value = value;
    }

    public static bool operator ==(Quality left, Quality right) => left.Equals(right);

    public static bool operator !=(Quality left, Quality right) => !left.Equals(right);

    public bool HasMaximumQuality => _value >= 50;

    public bool Equals(Quality other) => _value == other._value;

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is Quality && Equals((Quality)obj);
    }

    public override int GetHashCode() => (int)_value;

    public int CompareTo(object obj) => _value.CompareTo(((Quality)obj)._value);

    public override string ToString() => _value.ToString();

    public Quality Decrease()
    {
        if (_value > 0)
        {
            return new Quality(_value - 1);
        }

        return this;
    }

    public Quality Increase()
    {
        if (!HasMaximumQuality)
        {
            return new Quality(_value + 1);
        }

        return this;
    }
}
