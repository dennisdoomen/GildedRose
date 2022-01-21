namespace GildedRose;

public interface IItem
{
    bool IsExpired { get; }
    Quality Quality { get; }
    Days DaysOverdue { get; }
    void OnDayHasPassed();
}