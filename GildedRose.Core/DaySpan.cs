using System;

namespace GildedRose;

public readonly struct DaySpan : IComparable
{
    private readonly int value;

    public static DaySpan From(int value)
    {
        return new DaySpan(value);
    }

    private DaySpan(int value)
    {
        this.value = value;
    }

    public DaySpan ReduceByOne() => new(value - 1);

    public static bool operator ==(DaySpan left, DaySpan right) => left.Equals(right);

    public static bool operator !=(DaySpan left, DaySpan right) => !left.Equals(right);

    public static bool operator <(DaySpan left, DaySpan right) => left.value < right.value;

    public static bool operator >(DaySpan left, DaySpan right) => left.value > right.value;

    public static DaySpan operator -(DaySpan left) => new(-left.value);

    public bool IsOverdue => value < 0;
    public int DaysOverdue => value > 0 ? 0 : -value;

    public bool Equals(DaySpan other) => value == other.value;

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is DaySpan && Equals((DaySpan)obj);
    }

    public override int GetHashCode() => value;

    public int CompareTo(object obj) => value.CompareTo(((DaySpan)obj).value);

    public override string ToString() => value.ToString();
}
