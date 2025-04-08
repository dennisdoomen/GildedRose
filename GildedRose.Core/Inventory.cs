using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose;

public class Inventory : IEnumerable<Item>
{
    private readonly HashSet<Item> items = new();

    public Item HighestValued => items.OrderBy(i => i, Item.ByQualityComparer).Last();

    public IEnumerable<Item> OverdueItems => items.Where(i => i.IsOverdue).ToArray();


    public void Add(Item item) => items.Add(item);

    public void HandleDayChanges(int nrOfDays)
    {
        for (int i = 0; i < nrOfDays; i++)
        {
            foreach (Item item in items)
            {
                item.OnDayHasPassed();
            }
        }
    }

    #region Enumarable

    public IEnumerator<Item> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
