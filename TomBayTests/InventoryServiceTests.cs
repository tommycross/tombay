using TomBay;
using Xunit;

namespace TomBayTests;

public class InventoryServiceTests
{
    private readonly InventoryService _service;

    public InventoryServiceTests()
    {
        _service = new InventoryService();
    }

    [Fact]
    public async Task GetAllItemsAsync_ReturnsAllItems()
    {
        // Act
        var result = await _service.GetAllItemsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsItem_WhenItemExists()
    {
        // Act
        var result = await _service.GetItemByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsNull_WhenItemDoesNotExist()
    {
        // Act
        var result = await _service.GetItemByIdAsync(99);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddItemAsync_AddsItem()
    {
        // Arrange
        var newItem = new InventoryItem { Id = 3, Name = "NewItem" };

        // Act
        await _service.AddItemAsync(newItem);
        var result = await _service.GetItemByIdAsync(3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Id);
    }

    [Fact]
    public async Task UpdateItemAsync_UpdatesItem()
    {
        // Arrange
        var updatedItem = new InventoryItem { Id = 1, Name = "UpdatedItem" };

        // Act
        await _service.UpdateItemAsync(updatedItem);
        var result = await _service.GetItemByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("UpdatedItem", result.Name);
    }

    [Fact]
    public async Task DeleteItemAsync_DeletesItem()
    {
        // Act
        await _service.DeleteItemAsync(1);
        var result = await _service.GetItemByIdAsync(1);

        // Assert
        Assert.Null(result);
    }
}