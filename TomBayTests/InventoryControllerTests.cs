using Microsoft.AspNetCore.Mvc;
using Moq;
using TomBay;
using Xunit;

namespace TomBayTests;

public class InventoryControllerTests
{
    private readonly Mock<IInventoryService> _mockInventoryService;
    private readonly InventoryController _controller;

    public InventoryControllerTests()
    {
        _mockInventoryService = new Mock<IInventoryService>();
        _controller = new InventoryController(_mockInventoryService.Object);
    }

    [Fact]
    public async Task GetItems_ReturnsOkResult_WithListOfItems()
    {
        // Arrange
        var items = new List<InventoryItem>
        {
            new InventoryItem { Id = 1, Name = "Item1", Description = "Description1", Price = 123.45M, ImagePath = "foo/bar/qux1.jpg"},
            new InventoryItem { Id = 2, Name = "Item2", Description = "Description2", Price = 678.90M, ImagePath = "foo/bar/qux2.jpg" }
        };
        _mockInventoryService.Setup(service => service.GetAllItemsAsync()).ReturnsAsync(items);

        // Act
        var result = await _controller.GetItems();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnItems = Assert.IsType<List<InventoryItem>>(okResult.Value);
        Assert.Equal(2, returnItems.Count);
    }

    [Fact]
    public async Task GetItem_ReturnsOkResult_WithItem()
    {
        // Arrange
        var item = new InventoryItem
        {
            Id = 1,
            Name = "Item1",
            Description = "Description1",
            Price = 123.45M,
            ImagePath = "foo/bar/qux.jpg"
        };
        _mockInventoryService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync(item);

        // Act
        var result = await _controller.GetItem(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnItem = Assert.IsType<InventoryItem>(okResult.Value);
        Assert.Equal(1, returnItem.Id);
        Assert.Equal("Item1", returnItem.Name);
        Assert.Equal("Description1", returnItem.Description);
        Assert.Equal(123.45M, returnItem.Price);
        Assert.Equal("foo/bar/qux.jpg", returnItem.ImagePath);
    }

    [Fact]
    public async Task GetItem_ReturnsNotFound_WhenItemNotExists()
    {
        // Arrange
        _mockInventoryService.Setup(service => service.GetItemByIdAsync(1)).ReturnsAsync((InventoryItem)null);

        // Act
        var result = await _controller.GetItem(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreateItem_ReturnsCreatedAtAction()
    {
        // Arrange
        var item = new InventoryItem
        {
            Id = 1,
            Name = "Item1",
            Description = "Description1",
            Price = 123.45M,
            ImagePath = "foo/bar/qux.jpg"
        };

        // Act
        var result = await _controller.CreateItem(item);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetItem), createdAtActionResult.ActionName);
        Assert.Equal(item.Id, ((InventoryItem)createdAtActionResult.Value).Id);
    }

    [Fact]
    public async Task CreateItem_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        _controller.ModelState.AddModelError("Name", "Required");

        // Act
        var result = await _controller.CreateItem(new InventoryItem());

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }

    [Fact]
    public async Task UpdateItem_ReturnsNoContent()
    {
        // Arrange
        var item = new InventoryItem
        {
            Id = 1,
            Name = "Item1",
            Description = "Description1",
            Price = 123.45M,
            ImagePath = "foo/bar/qux.jpg"
        };

        // Act
        var result = await _controller.UpdateItem(1, item);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateItem_ReturnsBadRequest_WhenIdMismatch()
    {
        // Arrange
        var item = new InventoryItem
        {
            Id = 1,
            Name = "Item1",
            Description = "Description1",
            Price = 123.45M,
            ImagePath = "foo/bar/qux.jpg"
        };

        // Act
        var result = await _controller.UpdateItem(2, item);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task DeleteItem_ReturnsNoContent()
    {
        // Act
        var result = await _controller.DeleteItem(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}