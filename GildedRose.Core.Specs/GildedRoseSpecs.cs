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
                .WhichExpiresInDays(nrDaysUntilConcert)
                .WithQuality(QualityLevel.From(10)))
            .Build();

        // Act
        inventory.HandleDayChanges(daysPassed);

        // Assert
        inventory.Should().BeEquivalentTo(
        [
            new
            {
                Quality = QualityLevel.From(expectedQuality)
            }
        ]);
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
                .WithShelfLifeInDays(shelfLife))
            .Build();

        // Act
        inventory.HandleDayChanges(daysPassed);

        // Assert
        inventory.Should().BeEquivalentTo([
            new
            {
                Quality = QualityLevel.From(expectedQuality)
            }
        ]);
    }
}
