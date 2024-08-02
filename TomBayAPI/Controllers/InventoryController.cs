using Microsoft.AspNetCore.Mvc;

namespace TomBay;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService myService)
    {
        _inventoryService = myService;
    }

    /// <summary>
    /// Gets the list of all inventory items
    /// </summary>
    /// <returns>The list of inventory items</returns>
    // GET: api/Inventory
    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var result = await _inventoryService.GetAllItemsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Gets a specified inventory items
    /// </summary>
    /// <returns>The specified inventory item</returns>
    // GET: api/Inventory/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
        var result = await _inventoryService.GetItemByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    /// <summary>
    /// Creates a new inventory item
    /// </summary>
    /// <returns>The created inventory item</returns>
    // POST: api/Inventory
    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] InventoryItem item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _inventoryService.AddItemAsync(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    /// <summary>
    /// Updates a specified inventory item
    /// </summary>
    // PUT: api/Inventory/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, InventoryItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        await _inventoryService.UpdateItemAsync(item);
        return NoContent();
    }

    /// <summary>
    /// Deletes a specified inventory item
    /// </summary>
    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        await _inventoryService.DeleteItemAsync(id);
        return NoContent();
    }
}
