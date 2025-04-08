using System;

namespace GildedRose;

public readonly struct QualityLevel : IComparable
{
    private readonly uint _value;

    public static QualityLevel From(uint value)
    {
        return new QualityLevel(value);
    }

    private QualityLevel(uint value)
    {
        _value = value;
    }

    public static bool operator ==(QualityLevel left, QualityLevel right) => left.Equals(right);

    public static bool operator !=(QualityLevel left, QualityLevel right) => !left.Equals(right);

    public bool HasMaximumQuality => _value >= 50;

    public bool Equals(QualityLevel other) => _value == other._value;

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is QualityLevel && Equals((QualityLevel)obj);
    }

    public override int GetHashCode() => (int)_value;

    public int CompareTo(object obj) => _value.CompareTo(((QualityLevel)obj)._value);

    public override string ToString() => _value.ToString();

    public QualityLevel Decrease()
    {
        if (_value > 0)
        {
            return new QualityLevel(_value - 1);
        }

        return this;
    }

    public QualityLevel Increase()
    {
        if (!HasMaximumQuality)
        {
            return new QualityLevel(_value + 1);
        }

        return this;
    }
}
