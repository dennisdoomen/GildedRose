using System.Linq;

namespace GildedRose.Specs;

internal class InventoryBuilder
{
    private Inventory inventory = new();

    public Inventory Build()
    {
        if (!inventory.Any()) inventory = Program.CreateInventory();

        return inventory;
    }

    public InventoryBuilder With(BackstagePassBuilder builder)
    {
        inventory.Add(builder.Build());
        return this;
    }

    public InventoryBuilder With(SulfurasBuilder builder)
    {
        inventory.Add(builder.Build());
        return this;
    }
}
