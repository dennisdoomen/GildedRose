using FluentAssertions;
using Xunit;

namespace GildedRose.Specs;

public class GildedRoseSpecs
{
    [Theory]
    [InlineData(1, 11)]
    [InlineData(5, 15)]
    [InlineData(10, 20)]
    [InlineData(11, 22)]
    [InlineData(15, 30)]
    [InlineData(20, 45)]
    [InlineData(21, 0)]
    public void Backstage_passes_increase_in_quality_quickly_until_they_are_due(int daysPassed, uint expectedQuality)
    {
        // Arrange
        int nrDaysUntilConcert = 20;

        Inventory inventory = new InventoryBuilder()
            .With(new BackstagePassBuilder()
                .WhichExpires(new Days(nrDaysUntilConcert))
                .WithQuality(new Quality(10)))
            .Build();

        // Act
        inventory.HandleDayChanges(daysPassed);

        // Assert
        inventory.Should().BeEquivalentTo(new[]
        {
            new {ShelfLife = new Days(nrDaysUntilConcert - daysPassed), Quality = new Quality(expectedQuality)}
        });
    }

    [Theory]
    [InlineData(1, 80)]
    [InlineData(5, 80)]
    [InlineData(10, 80)]
    [InlineData(11, 80)]
    [InlineData(15, 80)]
    [InlineData(20, 80)]
    [InlineData(21, 80)]
    public void Sulfuras_never_loses_its_quality(int daysPassed, uint expectedQuality)
    {
        // Arrange
        int shelfLife = 20;

        Inventory inventory = new InventoryBuilder()
            .With(new SulfurasBuilder()
                .WithShelfLife(new Days(shelfLife)))
            .Build();

        // Act
        inventory.HandleDayChanges(daysPassed);

        // Assert
        inventory.Should().BeEquivalentTo(new[] {new {ShelfLife = new Days(shelfLife), Quality = new Quality(expectedQuality)}});
    }
}
