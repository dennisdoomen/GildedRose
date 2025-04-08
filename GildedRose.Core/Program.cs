using System;

namespace GildedRose;

public static class Program
{
    public static void Main()
    {
        Inventory inventory = CreateInventory();

        inventory.HandleDayChanges(5);

        Item highestValueItem = inventory.HighestValued;

        Console.WriteLine("The highest valued item is {0}", highestValueItem);

        foreach (Item item in inventory.OverdueItems)
        {
            Console.WriteLine("The item {0} is {1} day(s) overdue",
                item,
                item.DaysOverdue);
        }

        Console.ReadLine();
    }

    public static Inventory CreateInventory()
    {
        return
        [
            new Item("+5 Dexterity Vest", new LinearDevaluationStrategy(), DaySpan.From(10), QualityLevel.From(20)),
            new Item("Aged Brie", new LinearValuationStrategy(), DaySpan.From(2), QualityLevel.From(0)),
            new Item("Elixir of the Mongoose", new LinearDevaluationStrategy(), DaySpan.From(5), QualityLevel.From(7)),
            new Item("Sulfuras, Hand of Ragnaros", new LegendaryValuationStrategy(), DaySpan.From(0), QualityLevel.From(80)),
            new Item("Backstage passes to a TAFKAL80ETC concert", new TimeCriticalValuationStrategy(DaySpan.From(10), DaySpan.From(5)), DaySpan.From(15), QualityLevel.From(20)),
            new Item("Conjured Mana Cake", new LinearDevaluationStrategy(), DaySpan.From(3), QualityLevel.From(6))
        ];
    }
}
