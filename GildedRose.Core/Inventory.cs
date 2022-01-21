using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class Inventory : IEnumerable<IItem>
    {
        private readonly HashSet<IItem> _items = new();

        public IItem HighestValued
        {
            get { return _items.OrderBy(i => i, Item.ByQualityComparer).Last(); }
        }

        public IEnumerable<IItem> ExpiredItems
        {
            get { return _items.Where(i => i.IsExpired).ToArray(); }
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IItem item)
        {
            _items.Add(item);
        }

        public void HandleDayChanges(int nrOfDays)
        {
            for (int i = 0; i < nrOfDays; i++)
            {
                foreach (var item in _items)
                {
                    item.OnDayHasPassed();
                }
            }
        }
    }
}