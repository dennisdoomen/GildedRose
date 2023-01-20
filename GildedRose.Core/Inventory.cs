using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose;

public class Inventory : IEnumerable<IItem>
{
    private readonly HashSet<IItem> _items = new();

    public IItem HighestValued => _items.OrderBy(i => i, Item.ByQualityComparer).Last();

    public IEnumerable<IItem> ExpiredItems => _items.Where(i => i.IsExpired).ToArray();

    public IEnumerator<IItem> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(IItem item) => _items.Add(item);

    public void HandleDayChanges(int nrOfDays)
    {
        for (int i = 0; i < nrOfDays; i++)
            foreach (IItem item in _items)
                item.OnDayHasPassed();
    }
}
